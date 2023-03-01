using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pared : MonoBehaviour
{   
    public float TiempoSpawn;
    public float Tiempo=2;
    public GameObject ObjPared;
    public Vector3 Puerta;

    ///-------------PARED----------/
    private void OnCollisionStay(Collision other)
    {
        Vector3 RND = new Vector3(Random.Range(-10f, 10f), 2.10f, Random.Range(-10f, 10f));
        if (other.gameObject.name == "Personaje" && (TiempoSpawn >= 2))
        {
            this.ObjPared.transform.Rotate (Puerta);
        }
    }
    void Temporizador()
    {
        TiempoSpawn += Time.deltaTime;
        if (TiempoSpawn >= 2)
        {
            RestartTempo();
        }
    }
    void RestartTempo()
    {
        TiempoSpawn = Tiempo;
    }

    private void Update()
    {
        Temporizador();
    }
}

  