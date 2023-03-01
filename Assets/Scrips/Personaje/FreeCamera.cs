using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamera : MonoBehaviour
{
     public float RotationSpeed = 200f;
              
    void Start()
    {
        
    }

    void Update()
    {
        CameraFree();
    }
    //FreeCamera//
    public void CameraFree()
    {  
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            float rotationX = Input.GetAxis("Mouse Y");
            transform.Rotate(new Vector3(-rotationX * Time.deltaTime * RotationSpeed, 0, 0));
        }
       

        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(new Vector3(0, 0, -0.1f * Time.deltaTime * RotationSpeed));
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(new Vector3(0, 0, 0.1f * Time.deltaTime * RotationSpeed));


        }
    }
   
}
