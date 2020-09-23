using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiBackGround : MonoBehaviour
{

    public Material material;
    public float velocidadeX;
    Vector2 offset;    
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = new Vector2(velocidadeX, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(offset);
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
