using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    
    Material material;
    Vector2 offset;
    GameObject mainCamera;
    float velocidadeX;
   public Transform player;
    // Use this for initialization

    private void Awake()
    {

        velocidadeX = 100f;
        material = GetComponent<Renderer>().material;
        mainCamera = GameObject.Find("Camera");
    }

    void Start()
    {
    

        

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > 0)
        {
            offset = new Vector2(velocidadeX, 0f);
        }
        else if (player.transform.position.x < 0)
        {
            offset = new Vector2(-velocidadeX, 0);
        }
        else if (player.transform.position.y > 0 || player.transform.position.y < 0)
        {
            offset = new Vector2(0, 0);
        }
        material.mainTextureOffset += offset * Time.deltaTime;

    }
}
        
