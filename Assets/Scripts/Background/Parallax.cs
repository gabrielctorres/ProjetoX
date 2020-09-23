using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Parallax : MonoBehaviour
{
    private float length;
    private float startPos;
    public GameObject cam;
    public float paralaxEffect;
    public bool shouldMove = true;

    public bool isGameJustStarting = true;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        if(GetComponent<SpriteRenderer>() == true)
        {
            length = GetComponent<SpriteRenderer>().bounds.size.x;
        }
         
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        aplicarParallax();

        CinemachineConfiner confiner = GameObject.FindGameObjectWithTag("Confiner").
                                        GetComponent<CinemachineConfiner>();
        confiner.InvalidatePathCache();

    }

    private void aplicarParallax()
    {
        float temp = (cam.transform.position.x * (1 - paralaxEffect));
        float dist = (cam.transform.position.x * paralaxEffect);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        replicarCenario(temp, dist);
    }

    private void replicarCenario(float temp, float dist)
    {
        if(shouldMove)
        {
            if(temp > startPos + length) startPos += length;
            else if(temp < startPos - length && isGameJustStarting) startPos -= length;
        }
    }
}
