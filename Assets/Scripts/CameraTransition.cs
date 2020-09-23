using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    // Start is called before the first frame update
    float startTime;
    float timeToChange = 20f;
    string state = "Transition";
    int scenarioIndex = 0;

    public GameObject cam;
    public List<GameObject> cidade;
    public List<GameObject> deserto;
    List <List<GameObject>> paralaxObjects = new List<List<GameObject>>();

    public GameObject spawnObstaculos;

    private List<GameObject> parallaxAtivo;
    void Start()
    {
        GetComponent<Animator>().Play("Transition");
        InvokeRepeating("TransitionChange", timeToChange,timeToChange);
        parallaxAtivo = new List<GameObject>();
        paralaxObjects.Add(cidade);
        paralaxObjects.Add(deserto);
        trocarParallax();
    }

    private void trocarParallax()
    {

        foreach (GameObject obj in parallaxAtivo)
        {
            Destroy(obj);
        }
        parallaxAtivo.Clear();
        foreach ( GameObject obj in paralaxObjects[scenarioIndex] )
        {
            Vector3 position = obj.transform.position + (cam.transform.position);
            position.y = obj.transform.position.y;
            parallaxAtivo.Add(Instantiate(obj.gameObject, position , Quaternion.identity));
        }
        ativarParallax(true);
    }
    void TransitionChange ()
    {
        if(state == "NormalGame")
        {
            GetComponent<Animator>().Play("Transition");
            state = "Transition";
           
            scenarioIndex++;
            if(scenarioIndex >= paralaxObjects.Count)
            {
                scenarioIndex = 0;
            }
            trocarParallax();
            trocarObstaculos();
        }
        else
        {
            GetComponent<Animator>().Play("NormalGame");
            state = "NormalGame";
            ativarParallax(false);
            PredioSpawn obstaculos = spawnObstaculos.GetComponent<PredioSpawn>();
            obstaculos.shouldSpawn = false;
        }
    }

    private void Update() 
    {
        
    }

    private void ativarParallax(bool ativar)
    {
        foreach (GameObject parallaxObject in parallaxAtivo)
        {
            Parallax paralax = parallaxObject.GetComponent<Parallax>();
            paralax.cam = this.cam;
            paralax.shouldMove = ativar;
            paralax.isGameJustStarting = (Time.unscaledTime < timeToChange);
         //   parallaxObject.SetActive(ativar);
        }
    }

    private void trocarObstaculos()
    {
        PredioSpawn obstaculos = spawnObstaculos.GetComponent<PredioSpawn>();
        obstaculos.trocarCenario(scenarioIndex);
    }

}
