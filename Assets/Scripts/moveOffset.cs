using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for animating the background of the game scenes.
/// </summary>
public class MoveOffset : MonoBehaviour
{
    private Material material;
    public float velocX, velocY;
    private float offset;
    public float add;
   
   /// <summary>
   /// This function is responsible for rendering the scene material.
   /// </summary>
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    /// <summary>
    /// This function updates the displacement on the y axis, 
    /// making the scene appear to be moving.
    /// </summary>
    void Update()
    {
        offset += add;
        material.SetTextureOffset("_MainTex", new Vector2(offset*velocX, offset*velocY)); 
    }
}
