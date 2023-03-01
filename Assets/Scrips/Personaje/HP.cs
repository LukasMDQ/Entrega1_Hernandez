using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class HP : MonoBehaviour
{
    public GameObject target;
    public GameObject BarraHP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BarraHP.transform.LookAt(target.transform.position);
    }
}
