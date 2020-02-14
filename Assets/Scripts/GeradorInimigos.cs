using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{
    public GameObject enemy;
    public GameObject cam;

    public float timeToSpawn = 10f;
    private float nextTimeToSpawn = 0;
    private float startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = (cam.transform.position.x );
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);        

        if(Time.time >= nextTimeToSpawn)
        {
            nextTimeToSpawn = Time.time + timeToSpawn;
            GerarAviao();
        }
    }


    private void GerarAviao()
    {
        Instantiate(enemy, Randomize(), transform.rotation);
    }

    private Vector3 Randomize()
    {
        Vector3 randomPosition = Random.insideUnitSphere * 5;
        randomPosition += transform.position;
        randomPosition.z = 0;

        return randomPosition;
    }

}
