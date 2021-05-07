using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelaajaope : MonoBehaviour
{

    public float nopeus = 5.0f;

    private float vertikaalinenPyorinta = 0;
    private float horisontaalinenPyorinta = 0;
    private float xRotation = 0f;

    public float hyppyvoima = 0f;
    public float painovoima = 0f;
  
    private bool isGrounded = true;

    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        CharacterController hahmokontrolleri = GetComponent<CharacterController>();
        float horizontal = Input.GetAxis("Horizontal") * 5;
        float vertical = Input.GetAxis("Vertical") * 5;
        Vector3 nopeus = new Vector3(horizontal, 0, vertical);

        horisontaalinenPyorinta += Input.GetAxis("Mouse X") * 3;
        

        

        transform.localRotation = Quaternion.Euler(0, horisontaalinenPyorinta, 0);

        nopeus = transform.rotation * nopeus;


        nopeus.y = nopeus.y - painovoima * Time.deltaTime;



        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("hyppy");

            nopeus.y = nopeus.y + hyppyvoima;
            isGrounded = false;
        }
        hahmokontrolleri.Move(nopeus);
        nopeus.y = nopeus.y - painovoima * Time.deltaTime;

        if (Input.GetAxis("Vertical") != 0)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        hahmokontrolleri.Move(nopeus * Time.deltaTime);

    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }


    //private void OnDrawGizmosSelected()
    //{
       // Gizmos.color = Color.yellow;
       //Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    //}
}