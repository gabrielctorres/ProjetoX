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
    public ParticleSystem explosaoPrefab;
    public bool giroscopio = true;
    protected override void Start()
    {
        base.Start();
        Input.gyro.enabled = giroscopio;
        life = 1;
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
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Rotate(new Vector3(0, 0, rotationSpeed));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Rotate(new Vector3(0, 0, -rotationSpeed));
        }
    }
    IEnumerator destruindoPlayer()
    {
        yield return new WaitForSeconds(explosaoPrefab.time);
        Destroy(this.gameObject);       
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("1");
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
        Destroy(collision.gameObject);
    }
    
    //Colisao Sem Trigger
    private void OnCollisionEnter2D(Collision2D collision2)
    {
        switch (collision2.gameObject.tag)
        {
            case "Predios":
                life--;
                ParticleSystem  explosaoInstanciada = Instantiate(explosaoPrefab, transform.position, Quaternion.identity);
                explosaoInstanciada.Play();               
                StartCoroutine("destruindoPlayer");
                break;
        }
    }
}
