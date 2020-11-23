using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOffset : MonoBehaviour
{
    private Material material;
    public float velocX, velocY;
    private float offset;
    public float add;
   
    void Start()
    {
        material = GetComponent<Renderer>().material;
        
    }


    void Update()
    {
        offset += add;
        material.SetTextureOffset("_MainTex", new Vector2(offset*velocX, offset*velocY));
        
    }
}
