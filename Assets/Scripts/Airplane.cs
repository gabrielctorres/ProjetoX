using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Airplane : MonoBehaviour
{
    private float Timer = 3f;
    protected float velocidade  = 4f;   
    protected float fuel = 1f;
    protected Animator grafico;
    protected Rigidbody2D rb;

    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        grafico = GetComponent<Animator>();

    }
    
    protected void Update()
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
        Debug.Log(fuel);
    }

    protected void Moviment(){
        if(fuel >0){
            Move();
        }else{
            fall();
        }
    }

    public abstract void Move();

    protected void fall(){
        // provavelmente n vai precisar
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

    
}
