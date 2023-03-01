using UnityEngine;

public class Colisiones : MonoBehaviour
{
    public bool Agrandar = true;
    public GameObject jugador;
    
    private void OnTriggerEnter(Collider other)
    {
        if (Agrandar)
        {
            Debug.Log("entro al Portal");
            this.jugador.transform.localScale/=2;
            this.Agrandar= false;
        }
        else
        {
            Debug.Log("Salio del Portal");
            this.jugador.transform.localScale *= 2;
            this.Agrandar = true;
        }
    }
}





