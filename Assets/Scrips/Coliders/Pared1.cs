using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pared1 : MonoBehaviour
{   
    public float TiempoSpawn;
    public float Tiempo=2;
    public GameObject ObjPared;

    ///-------------PARED----------/
    private void OnCollisionStay(Collision other)
    {
        Vector3 RND = new Vector3(Random.Range(-10f, 10f), 2.10f, Random.Range(-10f, 10f));
        if (other.gameObject.name == "Personaje" && (TiempoSpawn >= 2))
        {
            Debug.Log("Golpeo la Pared");
            this.ObjPared.transform.position = (RND);
            this.ObjPared.transform.Rotate (RND);
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

  