﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavenHellCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider2D collider2D;
    public float teste = Mathf.Infinity;
    void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
        
        Debug.Log("before" + collider2D.size);
        collider2D.size = new Vector2(Mathf.Infinity, 1);
        Debug.Log("after" + collider2D.size);
    }
}
