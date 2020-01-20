using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaoScript : MonoBehaviour
{
    float speed = 4f;
    Animator animationBalao;
    int ValorRandom;
    GameObject playerScript;
    float distancia;
    // Start is called before the first frame update
    void Start()
    {
        animationBalao = GetComponent<Animator>();
        playerScript = GameObject.FindGameObjectWithTag("Player");
        SelecionarBalao();
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector3.Distance(playerScript.transform.position, transform.position);        
        MovimentarBalao();
    }


    void SelecionarBalao()
    {
        ValorRandom = Random.Range(1, 4);

        switch (ValorRandom)
        {
            case 1:
                animationBalao.SetBool("balao01", true);
                animationBalao.SetBool("balao02", false);
                animationBalao.SetBool("balao03", false);
                break;
            case 2:
                animationBalao.SetBool("balao01", false);
                animationBalao.SetBool("balao02", true);
                animationBalao.SetBool("balao03", false);
                break;
            case 3:
                animationBalao.SetBool("balao01", false);
                animationBalao.SetBool("balao02", false);
                animationBalao.SetBool("balao03", true);
                break;
            default:
                break;
        }


    }



    void MovimentarBalao()
    {
        if(distancia < 30)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
       
    }

}
