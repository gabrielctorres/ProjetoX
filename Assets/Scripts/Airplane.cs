using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Airplane : MonoBehaviour
{
    private float Timer = 3f;
    protected float velocidade  = 9f;   
    protected float fallSpeed = 0.6f;
    protected float rotationSpeed = 200f;
    protected float fuel = 1f;
    protected Animator grafico;
    protected Rigidbody2D rb;
    public bool morreu = false;
    public ParticleSystem explosaoPrefab;
    public float health = 100;
   public bool alive = true;
   public float timeAlive = 0;
   public float distanceTravelled = 0;
   public Vector3 startPosition;
    public float rotated;
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.centerOfMass = centerOfMass;
        grafico = GetComponent<Animator>();
        startPosition = transform.position;

    }
    
    protected virtual void FixedUpdate()
    {
        if(alive)
        {
            FuelSystem();
            Moviment();
            Animation();
            timeAlive += Time.deltaTime;
            distanceTravelled = Vector3.Distance(this.transform.position, startPosition);
        }
    }

    protected virtual void FuelSystem(){
        Timer -= Time.deltaTime;
        if(Timer < 0)
        {
            fuel -= 0.02f;
            Timer = 3;
        }
    }

    protected void rotate(float rotation)
    {
        rotated += Mathf.Abs(rotation) ;
        rb.angularVelocity = rotation * rotationSpeed;
    }

    protected void Moviment(){
        

        rb.velocity = transform.right * velocidade;
        
        transform.position = new Vector3(transform.position.x,
                                Mathf.Clamp(transform.position.y, -6f, 30f),
                                transform.position.z);
        

        Move();
        /* if( fuel > 0 ){
            Move();
        }else{  
            fall();
        } */
    }

    public void TakeDamage (float damage) 
    {
        this.health -= damage;

        if(this.health <= 0)
        {
            Die ();
        }
    }

    private void Die ()
    {
        morreu = true;
        
        alive = false;
        rb.velocity = new Vector2(0,0);
        rb.angularVelocity = 0;
        GetComponent<Renderer>().enabled = false;
        ParticleSystem  explosaoInstanciada = Instantiate(explosaoPrefab, transform.position, Quaternion.identity);
        explosaoInstanciada.Play(); 
        Destroy(explosaoInstanciada, 1f);
    }

    public abstract void Move();

    public float GetRotation()
    {
        return transform.rotation.eulerAngles.z;
    }
    protected void fall(){
        
        float rotation = this.GetRotation();
        //esquerda ou direita?
        if(rotation < 90 || rotation > 280)
        {
            rotate(-fallSpeed);
        }else
        {
            rotate(fallSpeed);
        }
    }
    protected void Animation()
    {
        float rotation = GetRotation();

        if (rotation >= 260 && rotation <= 360)
        {
            grafico.ResetTrigger("Reto");
            grafico.ResetTrigger("Virar2");
            grafico.SetTrigger("Virar");
        }
        else if (rotation <= 260 && rotation >= 180)
        {
            grafico.ResetTrigger("Reto");
            grafico.ResetTrigger("Virar");
            grafico.SetTrigger("Virar2");
        }
        else
        {
            grafico.ResetTrigger("Virar");
            grafico.ResetTrigger("Virar2");
            grafico.SetTrigger("Reto");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision2)
    {
        switch (collision2.gameObject.tag)
        {
            case "Predios":
                TakeDamage(this.health);
                break;
            case "terra":
                TakeDamage(this.health);
                break;
            case "ceu":
                TakeDamage(this.health);
                break;
            case "parede":
                TakeDamage(this.health);
                break;
            case "Enemy":
                TakeDamage(this.health);
                break;

        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        switch(other.tag){
            case "MundoBordas":
                Die();
                break;
        }
    }
    
}
