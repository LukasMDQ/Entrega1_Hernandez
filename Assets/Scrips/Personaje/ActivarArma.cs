using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarArma : MonoBehaviour
{
    public PickUp pickUp;
    public int numeroArma;
    void Start()
    {
        pickUp = GameObject.FindGameObjectWithTag("Personaje").GetComponent<PickUp>();
    }

   
    void Update()
    {
        
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.name == "Personaje") 
        {
            pickUp.ActivarArma(numeroArma);
            Destroy(gameObject);
        }
    }
}
