using System.Collections.Generic;
using UnityEngine;

public class PredioSpawn : MonoBehaviour
{    
    public List<GameObject> listaPredios = new List<GameObject>();
    public float speedSpawn;
    Vector2 posicaoSpawn;
    GameObject predioAux;
    void Start()
    {
        posicaoSpawn = transform.position;

        InvokeRepeating("spawnPredio", 1f, speedSpawn);
    }


    void spawnPredio() { 
    
        int predioSorteado = Random.Range(0, listaPredios.Count);
        posicaoSpawn.y = 0;
        if (predioAux != null)
        {
            int distancia = Random.Range(20, 80);
            SpriteRenderer spritePredio = predioAux.GetComponent<SpriteRenderer>();
            posicaoSpawn.x += spritePredio.size.x * transform.localScale.x + distancia;
            
        }

        predioAux = Instantiate(listaPredios[predioSorteado].gameObject, posicaoSpawn, Quaternion.identity);
    }

}