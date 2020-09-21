using System.Collections.Generic;
using UnityEngine;

public class PredioSpawn : MonoBehaviour
{    
    public List<GameObject> listaPredios = new List<GameObject>();
    public List<GameObject> listaPiramide = new List<GameObject>();
    public List<GameObject> listaArvore = new List<GameObject>();
    public List<GameObject> listaSeiNao = new List<GameObject>();

    List<List<GameObject>> cenarios = new List<List<GameObject>>();

    private int cenarioIndex = 0;

    public float speedSpawn;
    Vector2 posicaoSpawn;
    GameObject predioAux;
    void Start()
    {
        cenarios.Add(listaPredios);
        cenarios.Add(listaPiramide);
        cenarios.Add(listaArvore);
        cenarios.Add(listaSeiNao);
        posicaoSpawn = transform.position;

        InvokeRepeating("spawnPredio", 1f, speedSpawn);
    }


    void spawnPredio() { 
    
        int predioSorteado = Random.Range(0, listaPredios.Count);
        if (predioAux != null)
        {
            int distancia = Random.Range(20, 80);
            SpriteRenderer spritePredio = predioAux.GetComponent<SpriteRenderer>();
            posicaoSpawn.x += spritePredio.size.x * transform.localScale.x + distancia;
            
        }

        
        predioAux = Instantiate(cenarios[cenarioIndex][predioSorteado].gameObject, posicaoSpawn, Quaternion.identity);
    }

}