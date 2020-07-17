using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMoviment : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position,player.transform.position);
        if(dist > 29)
        {
            rb.velocity = transform.right * 20f;
        }
        else
        {
            rb.velocity = transform.right * 8f;

        }
    }




}
