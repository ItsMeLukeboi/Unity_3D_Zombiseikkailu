using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aarre : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Löysit aarteen!");
        }
        //if (collision.gameObject.name == "AMMUS")
       // {
            //If the GameObject's name matches the one you suggest, output this message in the console
         //   Debug.Log("Löysit aarteen!");
        //}
    }
}
