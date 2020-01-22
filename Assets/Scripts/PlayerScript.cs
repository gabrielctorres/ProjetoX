using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerScript : Airplane
{
    int pontos = 0;
    public Image fuelImg;
    public Joybutton jbScript;
    public Animator fuelAlert;
    public Text txtPontos;
    public bool giroscopio = true;
    protected override void Start()
    {
        base.Start();
        Input.gyro.enabled = giroscopio;
    }

    protected override void Update()
    {
        base.Update();
        txtPontos.text = pontos.ToString();        
    }

    protected override void FuelSystem(){
        base.FuelSystem();

        fuelImg.fillAmount = fuel;
        bool fuelAcabando = fuel <= 0.29;
       // fuelAlert.SetBool("acabando", fuelAcabando);

    }

    public override void Move()
    {

        

        if(Input.gyro.enabled)
        {
            transform.Rotate(new Vector3(0, 0, Input.acceleration.x) * rotationSpeed);
        }
        
        if (jbScript.usouBotao)
        {
            Vector3 direction = jbScript.InputDirection;
            transform.Rotate(new Vector3(0, 0, direction.y) * rotationSpeed);
        } 
    }
    
    // Colisao Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Moeda":
                pontos++;                
                break;
            case "Gasolina":
                fuel += 0.1f;               
                break;  
        }
        if(collision.tag != "MundoBordas") Destroy(collision.gameObject);
    }

    
    //Colisao Sem Trigger
    
}
