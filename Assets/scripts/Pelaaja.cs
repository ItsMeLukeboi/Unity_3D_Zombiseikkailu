using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelaaja : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5.0f;

    public Transform groundCheck;

    public float groundDistance = 0.2f;

    public LayerMask groundMask;

   // private Rigidbody rb;
    private float vertikaalinenPyorinta = 0;

    private float horisontaalinenPyorinta = 0;

    private float xRotation = 0f;

    public Animator anim;



    private bool isGrounded;

    public float hyppyvoima = 0f;
    public float painovoima = 0f;
    void Start()
    {
        //rb = GetComponent<Rigidbody>();

        anim = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance,groundMask);


        CharacterController hahmokontrolleri = GetComponent<CharacterController>();

        horisontaalinenPyorinta += Input.GetAxis("Mouse X") * 3;
        

    
      


        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;
        Vector3 nopeus = new Vector3(horizontal, 0, vertical);

        transform.localRotation = Quaternion.Euler(xRotation * 3, horisontaalinenPyorinta, 0);

        nopeus = transform.rotation * nopeus;



        nopeus.y -= painovoima * Time.deltaTime;
        hahmokontrolleri.Move(nopeus * Time.deltaTime);



        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("space key was pressed");
            nopeus.y += hyppyvoima;
            anim.SetBool("JumpF", true);

        }
        else
        {
            anim.SetBool("JumpF", false);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            
            nopeus.y += hyppyvoima;
            anim.SetBool("JumpU", true);
        }
        else
        {
            anim.SetBool("JumpU", false);
        }


        if (Input.GetAxis("Vertical") !=0)
        {
            anim.SetBool("Walk", true);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                anim.SetBool("Run", true);
                anim.SetBool("Walk", false);
                speed = 10.0f;
            }
        }
        
        else
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
            speed = 5.0f;
        }
        

        
    
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position,groundDistance);
    }

}
        
