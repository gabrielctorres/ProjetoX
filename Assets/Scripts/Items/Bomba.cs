using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{

    public float damage = 30f;
    private float velocidade = 10f;
    public ParticleSystem explosaoPrefab;

    public string target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    public void SetTarget(string targetTag)
    {
        target = targetTag;
    }
    void move ()
    {
        if(target != "")
        {
            GameObject g = GameObject.FindWithTag(target);

            if(g != null)
            {
                Vector3 targetPosition = g.transform.position;
                Vector3 direction = targetPosition - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion t = Quaternion.Euler(0, 0, angle);
                transform.rotation = Quaternion.Slerp(transform.rotation, t,  Time.deltaTime);
            }            

        }
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);

    }

    void Die ()
    {
        ParticleSystem  explosaoInstanciada = Instantiate(explosaoPrefab, transform.position, Quaternion.identity);
        explosaoInstanciada.Play(); 
        Destroy(gameObject);
        Destroy(explosaoInstanciada, 1f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        Airplane target = collision.transform.GetComponent<Airplane>();
        if(target != null)
        {
            target.TakeDamage(this.damage);
            Die();
        }
        
    }
}
