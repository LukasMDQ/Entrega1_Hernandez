
using JetBrains.Annotations;
using UnityEngine;

    
public class Movimiento : MonoBehaviour
{    
     public float Speed = 5f;
     public float Fuerza = 1f;
     public float RotSpeed = 1.0f;
     private Animator anima;
     private float x, y;
     public Rigidbody rb;
     public float SprintSpeed = 10;
     public float RotationSpeed = 200f;
     //Salto//
     public int GravCaida = 0;
     public bool PuedoSaltar;
     public float FuerzaSalto = 6f;
    //Ataques//
     public bool Espada_1M;
     public bool atacando;
     public bool avanzaGolpe;
     public float inpulsoGolpe = 10f;
    
     void Start()
     {
         PuedoSaltar = false;
         anima = GetComponent <Animator>();
     }
    
     void Update()
     {
        RotacionMouse();//ROTACION MOUSE//
        BloqueoCusor();//BLOQUEO CURSOR//
        //MovClasico();//MOVIMIENTO//
        Saltar();//SALTO//
        Sprint();//SPRINT//
        Ataque();//ATAQUE//
     }
    private void FixedUpdate()
    {
        if (avanzaGolpe) 
        {
            rb.velocity = transform.forward * inpulsoGolpe*Speed;
        }
        if (!atacando)
        {
            MovClasico();
        }
    }
     public void AvanzoSolo()
     {
        avanzaGolpe= true;

     }
    public void DejoAvanzar()
    {
        avanzaGolpe= false;
    }
     public void NoGolpeo()
     {
        atacando = false;
     }
     public void Ataque()//----------------------ATAQUES-------------------//
     {
        if (Input.GetKeyDown(KeyCode.Mouse0)&& PuedoSaltar && !atacando) 
        {
            if(Espada_1M)
            {
                anima.SetTrigger("GolpeEspada");
                atacando= true;
            }
            else
            {
                anima.SetTrigger("golpeo");
                atacando = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.F) && PuedoSaltar && !atacando)
        {
                      
                anima.SetTrigger("patada");
                atacando = true;
           
            
        }

     }
     public void MovPhysic()//-------------------MOVIMIENTO+FISICAS--------//
     {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveInput = new Vector3(horizontal, 0, vertical);
        rb.AddForce(moveInput * Speed * Time.deltaTime);
        //AnimacionMov//
        anima.SetFloat("velX", horizontal);
        anima.SetFloat("velY", vertical);
     }
     public void Saltar()//----------------------SALTO+ANIMACION-----------//

     {
        if (PuedoSaltar == true)
        {   
               if (!atacando)
               {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        
                        anima.SetBool("salto", true);
                        rb.AddForce(new Vector3(0, FuerzaSalto*Fuerza, 0), ForceMode.Impulse);
                        
                        
                    }
                    
               }
               
               anima.SetBool("piso", true);
        }
        else
        {
            Caida();
        }
     }
     public void Caida()//-----------------------CAIDA---------------------//
     {
         rb.AddForce(GravCaida *Physics.gravity);//CAER RAPIDO//
         anima.SetBool("piso", false);
         anima.SetBool("salto", false);
     }
     public void MovClasico()//------------------MOVIMIENTO----------------//
     {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        transform.Rotate(0, x, 0 * Time.deltaTime * RotSpeed);
        transform.Translate(0, 0, y * Time.deltaTime * Speed);

        anima.SetFloat("velX", x);
        anima.SetFloat("velY", y);

     }
     public void Sprint()//----------------------SPRINT+FUERZA-------------//
     {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = SprintSpeed;
            FuerzaSalto = 10f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed = 5;
            FuerzaSalto = 7;
        }
     }
     public void RotacionMouse()//---------------ROTACION MOUSE------------//
     {
        float rotationY = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, rotationY * Time.deltaTime * RotationSpeed, 0));
     }
     public void BloqueoCusor()//----------------BLOQUEAR CURSOR-----------//
     {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
     }
}

//-------LOGICA SALTO+DOBLESALTO------------//
/*
 
public void Saltar()
{
   if (PuedoSaltar == true)
   {
       if (Input.GetKeyDown(KeyCode.Space))
       {

           anima.SetBool("salto", true);
           rb.AddForce(new Vector3(0, FuerzaSalto, 0), ForceMode.Impulse);
       }
       //------DOBLE SALTO-------//
       /* else if (SaltoDoble)
        {
              rb.velocity= Vector3.zero;
              anima.SetBool("salto", true);
              rb.AddForce(new Vector3(0, FuerzaSalto, 0), ForceMode.Impulse);
              SaltoDoble=false;
        }
        anima.SetBool("piso", true);
    
   }
   else
   {
       Caida();
   }
    public void Caida()
    {
         anima.SetBool("piso", false);
         anima.SetBool("salto", false);
    }


       //if(PuedoSaltar == true)
       //  SaltoDoble= true;
  */

