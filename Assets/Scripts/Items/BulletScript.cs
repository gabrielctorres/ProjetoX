using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float speed = 20f;
    
    public ParticleSystem explosaoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
    void Die ()
    {
        ParticleSystem  explosaoInstanciada = Instantiate(explosaoPrefab, transform.position, Quaternion.identity);
        explosaoInstanciada.Play(); 
        Destroy(gameObject);
        Destroy(explosaoInstanciada, 1f);
    }
    private void OnTriggerExit2D(Collider2D other) {
        Airplane target = other.transform.GetComponent<Airplane>();
        if(target != null)
        {
            target.TakeDamage(target.health);
            Die();
        }         
    }   
     private void OnCollisionEnter2D(Collision2D other) {
        
    }
}
