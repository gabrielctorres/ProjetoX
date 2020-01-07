using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    List<Transform> posicoesSpawn = new List<Transform>();
    List<GameObject> prediosPrefabs = new List<GameObject>();
    float quantidadePredios;

    // Start is called before the first frame update
    void Start()
    {
        quantidadePredios = Random.Range(1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void gerandoPredios()
    {
        if(quantidadePredios == 1)
        {
            Transform posicaoSpawn = posicoesSpawn[Random.Range(1, posicoesSpawn.Count)];
        }else if(quantidadePredios == 2)
        {
            Transform posicaoSpawn = posicoesSpawn[Random.Range(1, posicoesSpawn.Count)];
            Transform posicaoSpawn2 = posicoesSpawn[Random.Range(2, posicoesSpawn.Count)];
        }
        for (int i = 0; i < posicoesSpawn.Count; i++)
        {

        }
    }


}
