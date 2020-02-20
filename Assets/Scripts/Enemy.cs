using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Airplane
{
   private GameObject player;
   public Bomba bomba;

   public Transform spawnPoint;
   
   public float timeToShot = 10f;
   public float nextTimeToShot = 0;

   private Rigidbody2D rb;
   protected void Start()
   {
       velocidade = 5f;
       base.Start();
       player = GameObject.FindWithTag("Player");
       rb = gameObject.GetComponent<Rigidbody2D>();
       velocidade = 8f;
   }

   public override void Move()
   {
        findFuel();
        findPlayer();
   }  


    private void ia()
    {
        float distance = Distance();

        if(distance <=30)
        {

        }

    }

    private float Distance()
    {
        return Vector2.Distance(player.transform.position, transform.position);
    }
   private void findPlayer()
   {
        Vector3 playerPosition = (player != null) ? player.transform.position : Vector3.up;
        Vector3 direction = playerPosition - transform.position;
        float distance = direction.magnitude;

        if(distance < 20)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 30);
            if(hit != null && 
                hit.collider != null ){

                //Debug.Log(hit.collider.tag);
                if(hit.collider.tag == "Player" && Time.time >= nextTimeToShot)
                {
                    nextTimeToShot = Time.time +  timeToShot;
                    Instantiate(bomba, spawnPoint.position, transform.rotation);
                    bomba.SetTarget("Player");
                }
            }

            int sign = (direction.y) >= 0 ? 1 : -1;
            float offset = (sign >=0) ? 0 : 360;
            float angle = Vector2.Angle(Vector2.right, direction) * sign + offset;
            Quaternion rotate = Quaternion.Euler(0,0, angle);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotate, rotationSpeed * Time.deltaTime);
        }

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
                int sign = (direction.y) >= 0 ? 1 : -1;
                float offset = (sign >=0) ? 0 : 360;
                float angle = Vector2.Angle(Vector2.right, direction) * sign + offset;
                Quaternion target = Quaternion.Euler(0, 0, angle);
                transform.rotation = Quaternion.Slerp(transform.rotation, target,  1);
                
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
