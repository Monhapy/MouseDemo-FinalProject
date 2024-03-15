using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnemy : MonoBehaviour
{
    public Color hitColor = Color.red;
    
    public void Hit()
    {
        Debug.Log("Hitted");
        Renderer renderer = GetComponent<Renderer>();
        Rigidbody rb = GetComponent<Rigidbody>();
        
        rb.AddForce(new Vector3(0f,0f,5f),ForceMode.Impulse);
        renderer.material.color = hitColor;
        
    }
}
