using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{    
    public List<GameObject> listaItens = new List<GameObject>();
    public float speedSpawn;
    Vector2 posicaoSpawn;
    GameObject ItemAux;
    void Start()
    {
        posicaoSpawn = transform.position;

        InvokeRepeating("spawnPredio", 1f, speedSpawn);
    }


    void spawnPredio() { 
    
        int predioSorteado = Random.Range(0, listaItens.Count);
        posicaoSpawn.y = 4;
        if (ItemAux != null)
        {
            int distancia = Random.Range(40, 160);
            SpriteRenderer spritePredio = ItemAux.GetComponent<SpriteRenderer>();
            posicaoSpawn.x += spritePredio.size.x * transform.localScale.x + distancia;
            
        }

        ItemAux = Instantiate(listaItens[predioSorteado].gameObject, posicaoSpawn, Quaternion.identity);
    }

}