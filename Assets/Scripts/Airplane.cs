using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Airplane : MonoBehaviour
{
    private float Timer = 3f;
    protected float velocidade  = 10f;   
    protected float fallSpeed = 0.6f;
    protected float rotationSpeed = 5f;
    protected float fuel = 1f;
    protected Animator grafico;
    protected Rigidbody2D rb;

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
        LimitandoTela();
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

        //está sempre caindo
        fall();

        // se tem combustivel entao move
        if(fuel >0){
            Move();
        }
    }

    public abstract void Move();

    private void fall(){
        
        float rotation = transform.rotation.eulerAngles.z;
        
        //esquerda ou direita?
        if(rotation < 90 || rotation > 280)
        {
            transform.Rotate(new Vector3(0, 0, -fallSpeed));
        }else
        {
            transform.Rotate(new Vector3(0, 0, fallSpeed));
        }
    }
    protected void Animation()
    {
        float rotation = transform.rotation.eulerAngles.z;

        if (rotation >= 260 && rotation <= 360)
        {
            grafico.ResetTrigger("Reto");
            grafico.SetTrigger("Virar");
        }
        else if (rotation < 260 && rotation > 180)
        {
            
        }
        else
        {
            grafico.ResetTrigger("Virar");
            grafico.SetTrigger("Reto");
        }
    }
    void LimitandoTela()
    {
        // isso aqui deveria estar no codigo da tela
        // pra ia tbm não sair. E pra não ter codigo redundante hehe
        if (transform.position.y <= 24.9f || transform.position.y >= -7.2f)
        {
            float YPos = Mathf.Clamp(transform.position.y, -7.2f, 24.9f);
            transform.position = new Vector3(transform.position.x, YPos, transform.position.z);
        }
    }

    
}
