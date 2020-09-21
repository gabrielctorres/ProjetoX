using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    // Start is called before the first frame update
    float startTime;
    float timeToChange = 3f;
    string state = "Transition";
    int scenarioIndex = 0;

    public List<GameObject> paralaxObjects;
    void Start()
    {
        GetComponent<Animator>().Play("Transition");
        InvokeRepeating("TransitionChange", timeToChange,timeToChange);
    }

    void TransitionChange ()
    {
        if(state == "NormalGame")
        {
            GetComponent<Animator>().Play("Transition");
            state = "Transition";
            ativarParallax(true);
        }
        else
        {
            GetComponent<Animator>().Play("NormalGame");
            state = "NormalGame";
            ativarParallax(false);
        }
    }

    private void Update() 
    {
        
    }

    private void ativarParallax(bool ativar)
    {
        foreach (GameObject parallaxObject in paralaxObjects)
        {
            Parallax paralax = parallaxObject.GetComponent<Parallax>();
            paralax.shouldMove = ativar;
         //   parallaxObject.SetActive(ativar);
        }
    }
}
