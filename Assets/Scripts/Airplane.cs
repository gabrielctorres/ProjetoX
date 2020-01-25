using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Airplane : MonoBehaviour
{
    private float Timer = 3f;
    protected float velocidade  = 8f;   
    protected float fallSpeed = 0.6f;
    protected float rotationSpeed = 3f;
    protected float fuel = 1f;
    protected Animator grafico;
    protected Rigidbody2D rb;

    public ParticleSystem explosaoPrefab;
    protected float health = 100;
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        grafico = GetComponent<Animator>();
    }
    
    protected virtual void Update()
    {
        FuelSystem();
        Moviment();
        Animation();
    }

    protected virtual void FuelSystem(){
        Timer -= Time.deltaTime;
        if(Timer < 0)
        {
            fuel -= 0.02f;
            Timer = 3;
        }
    }

    protected void Moviment(){
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        //limita tela
        transform.position = new Vector3(transform.position.x,
                                Mathf.Clamp(transform.position.y, -6f, 30f),
                                transform.position.z);
        fall();
        if( fuel > 0 ){
            Move();
        }
    }

    public void TakeDamage (float damage) 
    {
        this.health -= damage;

        if(this.health <= 0)
        {
            Die ();
        }
        Debug.Log ("ouch!!!");
    }

    private void Die ()
    {
        ParticleSystem  explosaoInstanciada = Instantiate(explosaoPrefab, transform.position, Quaternion.identity);
        explosaoInstanciada.Play(); 
        Destroy(gameObject);
        Destroy(explosaoInstanciada, 1f);
    }

    public abstract void Move();

    public float GetRotation()
    {
        return transform.rotation.eulerAngles.z;
    }
    private void fall(){
        
        float rotation = this.GetRotation();
        //esquerda ou direita?
        if(rotation < 90 || rotation > 280)
        {
            transform.Rotate(new Vector3(0, 0, -fallSpeed), Space.Self);
        }else
        {
            transform.Rotate(new Vector3(0, 0, fallSpeed), Space.Self);
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
        }
    }
    
}
