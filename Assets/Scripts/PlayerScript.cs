using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : Airplane
{
    int pontos = 0;
    public Image fuelImg;
    public Joybutton jbScript;
    public Animator fuelAlert;
    public Text txtPontos;  

    protected override void Start()
    {
        base.Start();
        Input.gyro.enabled = true;
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

        if(transform.rotation.z < 0){
            velocidade = 12;
        }
        else
        {
            velocidade = 8f;
        }

        if(Input.gyro.enabled)
        {
            transform.Rotate(new Vector3(0, 0, Input.acceleration.x) * rotationSpeed);
        }
        
        if (jbScript.usouBotao)
        {
            Vector3 direction = jbScript.InputDirection;
            transform.Rotate(new Vector3(0, 0, direction.y) * rotationSpeed);
        } 
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Rotate(new Vector3(0, 0, rotationSpeed));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Rotate(new Vector3(0, 0, -rotationSpeed));
        }
    }

    
    // Colisao
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
        Destroy(collision.gameObject);
    }

}
