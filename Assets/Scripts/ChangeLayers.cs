using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayers : MonoBehaviour
{
    public List<SpriteRenderer> spriteFlorest = new List<SpriteRenderer>();
    public List<SpriteRenderer> cenary = new List<SpriteRenderer>();
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 10f)
        {
            ChangeSprite();
        }
    }



    void ChangeSprite()
    {
        for (int i = 0; i < spriteFlorest.Count; i++)
        {
            cenary[i].sprite = spriteFlorest[i].sprite;
        }
    }
}
