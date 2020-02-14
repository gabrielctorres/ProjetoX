using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    [System.Serializable]
    public class DropItens
    {
        public string nome;
        public GameObject item;
        public int dropRarity;
    }

    public List<DropItens> TabelaLoot = new List<DropItens>();
    public int dropChance;
    public float speedSpawn;
    
    void Start()
    {
        InvokeRepeating("calculandoLoot", 1f, speedSpawn);
    }

    void calculandoLoot()
    {
        int calc_dropChance = Random.Range(0, 101);

        if (calc_dropChance > dropChance)
        {
            return;
        }

        int itemWeight = 0;

        for (int i = 0; i < TabelaLoot.Count; i++)
        {
            itemWeight += TabelaLoot[i].dropRarity;
        }

        int valorRandomico = Random.Range(0, itemWeight);
        GameObject aux = null;
        for (int j = 0; j < TabelaLoot.Count; j++)
        {
            if (valorRandomico <= TabelaLoot[j].dropRarity)
            {
                if(aux != null)
                {
                    float distanciaSpawn = Random.Range(3f, 10f);
                    Vector2 posicaoSpawn = aux.transform.position;
                    posicaoSpawn.x +=  distanciaSpawn;
                    aux = Instantiate(TabelaLoot[j].item, posicaoSpawn, Quaternion.identity);
                }
                else
                {
                    aux = Instantiate(TabelaLoot[j].item, transform.position, Quaternion.identity);
                }

                return;
            }
            valorRandomico -= TabelaLoot[j].dropRarity;
        }
        
    }
}