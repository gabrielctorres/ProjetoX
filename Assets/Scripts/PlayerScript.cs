using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerScript : Airplane
{
    int pontos = 0;
    public Image fuelImg;
    public Joybutton jbScript;
    public Animator fuelAlert;
    public Text txtPontos;
    public bool giroscopio = true;
    
    public GameObject Bullet;
    public GameObject spawnBullet;
    public float timeToShot = -1f;
    public float nextTimeToShot = 0;
    public Vector3 rotation;
    public bool training = false;


    //coletando infos para ia
    public float visibleDistance = 20.0f;
    List<string> trainingData = new List<string>();
    StreamWriter tdf;

    protected override void Start()
    {
        base.Start();
        Input.gyro.enabled = giroscopio;
        rotation = transform.rotation.eulerAngles;     
        string path = Application.dataPath + "/trainingData2.txt";
        
        if(training)
            tdf = File.CreateText(path);
    }

    void OnApplicationQuit()
    {
        if(training)
        {
            foreach (string td in trainingData)
            {
                tdf.WriteLine(td);
            }
            tdf.Close();
        }
    }

    float Round(float x)
    {
        return (float) System.Math.Round(x, System.MidpointRounding.AwayFromZero) / 2.0f;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        
        Debug.DrawRay(transform.position, transform.right * visibleDistance, Color.green);
        Debug.DrawRay(transform.position, transform.up * visibleDistance, Color.green);
        Debug.DrawRay(transform.position, -transform.up * visibleDistance, Color.green);
        
       Debug.DrawRay(transform.position, (Quaternion.Euler(0, 0, 45) * transform.right) * visibleDistance, Color.green);
        Debug.DrawRay(transform.position, (Quaternion.Euler(0, 0, -45) * transform.right) * visibleDistance, Color.green);

        

        float rDist = 0, upDist = 0, downDist = 0, upDegDist = 0, downDegDist= 0;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, visibleDistance);
        if(hit.collider != null)
        {
            Debug.Log("bateu em algo na frente");
            rDist = 1 - Round(hit.distance/visibleDistance);
            Debug.Log(rDist);
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

        string td = rDist + "," + upDist + "," + downDist + "," +
                    upDegDist + "," + downDegDist + "," + 
                    Round(jbScript.InputDirection.y);


        if(jbScript.InputDirection.y != 0 && training){
            if(!trainingData.Contains(td))
            {
                trainingData.Add(td);
            }
        }

    }
    
    protected override void FuelSystem(){
        base.FuelSystem();

        fuelImg.fillAmount = fuel;
        bool fuelAcabando = fuel <= 0.29;
       // fuelAlert.SetBool("acabando", fuelAcabando);

    }

    public override void Move()
    {
        if(Input.gyro.enabled)
        {
            transform.Rotate(new Vector3(0, 0, Input.acceleration.x) * rotationSpeed);
        }
        
        if (jbScript.usouBotao)
        {
            Vector3 direction = jbScript.InputDirection;
            this.rotate(direction.y);
        } else{
            this.rotate(0);
        }
        
    }

    public void btnAtirar()
    {
        Instantiate(Bullet,spawnBullet.transform.position,transform.rotation);
        
    }
    
    // Colisao Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Moeda":
                pontos++;                
                break;
            case "Gasolina":
                fuel += 0.1f;               
                break;  
        }
        if(collision.tag != "MundoBordas") Destroy(collision.gameObject);
    }

    
    //Colisao Sem Trigger
    
}
