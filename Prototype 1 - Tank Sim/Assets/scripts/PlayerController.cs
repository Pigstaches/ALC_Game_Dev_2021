using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 25.0f;

    private float turnSpeed = 50.0f;


    private float hInput;

    private float vInput; 

    // Update is called once per frame
    void Update()
    {
        // get horizontal and vertical inputs
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");


        //moves tank forward back
        transform.Translate(Vector3.forward * speed * Time.deltaTime * vInput);
      
        //rootate tank left and right
        transform.Rotate(Vector3.up, turnSpeed * hInput * Time.deltaTime );
    }
}
