using System.Collections.Generic;
using UnityEngine;

public class PredioSpawn : MonoBehaviour
{    
    public List<GameObject> listaPredios = new List<GameObject>();
    public List<GameObject> listaPiramide = new List<GameObject>();

    public GameObject cam;
    public List<List<GameObject>> cenarios = new List<List<GameObject>>();

    public int cenarioIndex = 0;

    public float speedSpawn = 0.5f;
    Vector2 posicaoSpawn;
    GameObject predioAux;
    List<GameObject> obstaculosAtivos = new List<GameObject>();
    public bool shouldSpawn = true;
    void Start()
    {
        cenarios.Add(listaPredios);
        cenarios.Add(listaPiramide);

    }

    private void Update() {
        float distance = Vector3.Distance(cam.transform.position, transform.position);
        if(distance < 50)
        {            
            Vector3 newPosition = transform.position;
            int distancia = Random.Range(0, 50);
            newPosition.x = cam.transform.position.x + 80 +distancia;
            transform.position = newPosition;
            posicaoSpawn = transform.position;
            if(shouldSpawn)
            {
                spawnPredio();
            }
        }
    }


    void spawnPredio() {    
        int predioSorteado = Random.Range(0, cenarios[cenarioIndex].Count);
        obstaculosAtivos.Add(Instantiate(cenarios[cenarioIndex][predioSorteado].gameObject, posicaoSpawn, Quaternion.identity));
    }
    public void trocarCenario(int cenarioIndex)
    {
        this.cenarioIndex = cenarioIndex;

        SpriteRenderer spritePredio = obstaculosAtivos[obstaculosAtivos.Count - 1].GetComponent<SpriteRenderer>();

        if(this.cenarioIndex >= cenarios.Count)
        {
            this.cenarioIndex = 0;
        }
        foreach (GameObject obj in obstaculosAtivos)
        {
            Destroy(obj);
        }
        obstaculosAtivos.Clear();
        posicaoSpawn.x = cam.transform.position.x;
        this.shouldSpawn = true;
    }

}