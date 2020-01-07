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

    private void Start()
    {
        base.Start();
        Input.gyro.enabled = true;
    }

    void Update()
    {
        base.Update();

        LimitandoTela();
        txtPontos.text = pontos.ToString();
        Debug.Log("Teste");
 
    }

    protected override void FuelSystem(){
        base.FuelSystem();

        fuelImg.fillAmount = fuel;
        bool fuelAcabando = fuel <= 0.29;
        fuelAlert.SetBool("acabando", fuelAcabando);
        Debug.Log("AAA");

    }

    public override void Move()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);

        if(Input.gyro.enabled)
        {
            transform.Rotate(new Vector3(0, 0, Input.acceleration.x));
        }
        
        if (jbScript.usouBotao)
        {
            Vector3 direction = jbScript.InputDirection;
            transform.Rotate(new Vector3(0, 0, direction.y));
        } 
    }

    void LimitandoTela()
    {
        // isso aqui deveria estar no codigo da tela
        // pra ia tbm não sair. E pra não ter codigo redundante
        if (transform.position.y <= 24.9f || transform.position.y >= -7.2f)
        {
            float YPos = Mathf.Clamp(transform.position.y, -7.2f, 24.9f);
            transform.position = new Vector3(transform.position.x, YPos, transform.position.z);
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
        Destroy(collision);
    }

}
