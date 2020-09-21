using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Enemy : Airplane
{
    private GameObject player;
    public Bomba bomba;

    public Transform spawnPoint;

    public float timeToShot = 10f;
    public float nextTimeToShot = 0;

    ANN redeNeural;
    public float visibleDistance = 20.0f;

    bool trainingDone = false;
    public int tempoAprendizado = 1000;

    float trainingProgress = 0;
    double performance = 0;
    double ultimaPerformance = 1; 

    public bool loadFromFile = true;


    void OnGUI()
    {
        GUI.Label (new Rect (25, 25, 250, 30), "SSE: " + ultimaPerformance);
        GUI.Label (new Rect (25, 40, 250, 30), "Alpha: " + redeNeural.alpha);
        GUI.Label (new Rect (25, 55, 250, 30), "Trained: " + trainingProgress);
    }

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player");

        redeNeural = new ANN(5,1,1,10,0.5);

        if(loadFromFile)
        {
            LoadWeightsFromFile();
            trainingDone = true;
        }
        else
            StartCoroutine(LoadTrainingSet());
    }

     IEnumerator LoadTrainingSet()
    {

        
        string path = Application.dataPath + "/trainingData.txt";
        string line;
        if(File.Exists(path))
        {
            int lineCount = File.ReadAllLines(path).Length;
            StreamReader tdf = File.OpenText(path);
            List<double> calcOutputs = new List<double>();
            List<double> inputs = new List<double>();
            List<double> outputs = new List<double>();

            for(int i = 0; i < tempoAprendizado; i++)
            { 
                performance = 0;
                tdf.BaseStream.Position = 0;
                string currentWeights = redeNeural.PrintWeights();
                while((line = tdf.ReadLine()) != null)  
                {  
                    string[] data = line.Split(',');
                    float thisError = 0;
                    if(System.Convert.ToDouble(data[5]) != 0)
                    {
                        inputs.Clear();
                        outputs.Clear();
                        inputs.Add(System.Convert.ToDouble(data[0]));
                        inputs.Add(System.Convert.ToDouble(data[1]));
                        inputs.Add(System.Convert.ToDouble(data[2]));
                        inputs.Add(System.Convert.ToDouble(data[3]));
                        inputs.Add(System.Convert.ToDouble(data[4]));

                        double o1 = Map(0, 1, -1, 1, System.Convert.ToSingle(data[5]));
                        outputs.Add(o1);

                        calcOutputs = redeNeural.Treinar(inputs,outputs); 
                        thisError = Mathf.Pow((float)(outputs[0] - calcOutputs[0]),2);
                    }
                    performance += thisError;
                } 
                performance /= lineCount;
                
                if(ultimaPerformance < performance)
                {
                	redeNeural.LoadWeights(currentWeights);
                	redeNeural.alpha = Mathf.Clamp((float) redeNeural.alpha - 0.001f,0.01f,0.9f);
                }
                else 
                {
                	redeNeural.alpha = Mathf.Clamp((float) redeNeural.alpha + 0.001f,0.01f,0.9f);
                	ultimaPerformance = performance;
                }

                yield return null;
            }
                
        }
        Debug.Log("de hoje Ta Pago!");
        trainingDone = true;
        SaveWeightsToFile();
    }

    void SaveWeightsToFile()
    {
        string path = Application.dataPath + "/weights.txt";
        StreamWriter wf = File.CreateText(path);
        wf.WriteLine (redeNeural.PrintWeights());
        wf.Close();
    }

    void LoadWeightsFromFile()
    {
    	string path = Application.dataPath + "/weights.txt";
    	StreamReader wf = File.OpenText(path);

        if(File.Exists(path))
        {
        	string line = wf.ReadLine();
        	redeNeural.LoadWeights(line);
        }
    }
    float Map (float newfrom, float newto, float origfrom,float origto, float value) 
    {
    	if (value <= origfrom)
        	return newfrom;
    	else if (value >= origto)
        	return newto;
    	return (newto - newfrom) * ((value - origfrom) / (origto - origfrom)) + newfrom;
	}

    float Round(float x) 
    {   
        return (float)System.Math.Round(x, System.MidpointRounding.AwayFromZero) / 2.0f;
    }

    public void init()
    {

    }
    public override void Move()
    {
        if(!trainingDone) return;

        List<double> calcOutputs = new List<double>();
        List<double> inputs = new List<double>();
        List<double> outputs = new List<double>();

        float rDist = 0, upDist = 0, downDist = 0, upDegDist = 0, downDegDist= 0;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, visibleDistance);
        if(hit.collider != null)
        {
            rDist = 1 - Round(hit.distance/visibleDistance);
        }

        hit = Physics2D.Raycast(transform.position, transform.up, visibleDistance);
        if(hit.collider != null)
        {
            upDist = 1 - Round(hit.distance/visibleDistance);
        }

        hit = Physics2D.Raycast(transform.position, -transform.up, visibleDistance);
        if(hit.collider != null)
        {
            downDist = 1 - Round(hit.distance/visibleDistance);
        }

        hit = Physics2D.Raycast(transform.position, 
                    Quaternion.Euler(0, 0, 45) * transform.right, visibleDistance);
        if(hit.collider != null)
        {
            upDegDist = 1 - Round(hit.distance/visibleDistance);
        }

        hit = Physics2D.Raycast(transform.position, 
                    Quaternion.Euler(0, 0, -45) * transform.right, visibleDistance);
        if(hit.collider != null)
        {
            downDegDist = 1 - Round(hit.distance/visibleDistance);
        }

        inputs.Add(rDist);
        inputs.Add(upDist);
        inputs.Add(downDist);
        inputs.Add(upDegDist);
        inputs.Add(downDegDist);
        outputs.Add(0);

        calcOutputs = redeNeural.CalcOutput(inputs, outputs);
        float rot = Map(-1,1,0,1,(float) calcOutputs[0]);

        rotate(rot);
    }
     protected override void FixedUpdate()
    {
        if(!trainingDone) return;
        base.FixedUpdate();
        
       

    }  

    public void Update()
    {
       
        Debug.DrawRay(transform.position, transform.right * visibleDistance, Color.green);
        Debug.DrawRay(transform.position, transform.up * visibleDistance, Color.green);
        Debug.DrawRay(transform.position, -transform.up * visibleDistance, Color.green);
        

        Debug.DrawRay(transform.position, (Quaternion.Euler(0, 0, 45) * transform.right) * visibleDistance, Color.green);
        Debug.DrawRay(transform.position, (Quaternion.Euler(0, 0, -45) * transform.right) * visibleDistance, Color.green);
        

        

    }
    private void shoot()
    {
        if(Time.time >= nextTimeToShot)
        {
            nextTimeToShot = Time.time +  timeToShot;
            Instantiate(bomba, spawnPoint.position, transform.rotation);
            bomba.SetTarget("Player");
        }
    }

    private void followPlayer()
    {
        Vector3 playerPosition = (player != null) ? player.transform.position : Vector3.up;
        Vector3 direction = playerPosition - transform.position;
        float distance = direction.magnitude;
                        
        int sign = (direction.y) >= 0 ? 1 : -1;
        float offset = (sign >=0) ? 0 : 360;
        float angle = Vector2.Angle(Vector2.right, direction) * sign + offset;
        Quaternion rotate = Quaternion.Euler(0,0, angle);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Gasolina":
                fuel += 0.1f;
                Destroy(collision.gameObject);
                break;
        }
    }

}
