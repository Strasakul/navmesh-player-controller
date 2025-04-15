using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{
    
    [Header("Settings:")]
    [SerializeField]
    private float timeSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(timeSpeed*Time.deltaTime, 0, 0);
        
        
    }
}
