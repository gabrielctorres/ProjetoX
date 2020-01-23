using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Airplane
{
   public GameObject player;
   public Bomba bomba;
   
   public float timeToShot = 10f;
   public float nextTimeToShot = 0;
   protected void Start()
   {
       base.Start();
       player = GameObject.FindWithTag("Player");
   }

   public override void Move()
   {
        findFuel();
        findPlayer();
   }  

   private void findPlayer()
   {
        Vector3 playerPosition = (player != null) ? player.transform.position : Vector3.up;
        Vector3 direction = playerPosition - transform.position;
        float distance = direction.magnitude;

        if(distance < 30)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 30);
            if(hit != null && 
                hit.collider != null ){

                //Debug.Log(hit.collider.tag);
                if(hit.collider.tag == "Player" && Time.time >= nextTimeToShot)
                {
                    nextTimeToShot = Time.time +  timeToShot;
                    Instantiate(bomba, transform.position, transform.rotation);
                    bomba.SetTarget("Player");
                }
            }
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion target = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * rotationSpeed);

   }

   private void findFuel()
   {
       GameObject[] fuels = GameObject.FindGameObjectsWithTag("Gasolina");
        GameObject fuel = null;
        float nearest = float.MaxValue;

        foreach (GameObject f in fuels)
        {
            float x = (f.transform.position - transform.position).magnitude;
            if(x < nearest)
            {
                nearest = x;
                fuel = f;
            }
        }
        if( fuel != null)
        {
            Vector3 fuelPosition = fuel.transform.position;

            Vector3 direction = fuel.transform.position - transform.position;
            if(nearest < 20)
            {
                Debug.Log("viu a gasolina");
                this.velocidade = 12f;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion target = Quaternion.Euler(0, 0, angle);
                transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * rotationSpeed);
                
            }
        }
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
