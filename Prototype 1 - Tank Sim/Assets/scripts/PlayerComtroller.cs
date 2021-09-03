using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComtroller : MonoBehaviour
{
    private float speed;
    private float turnSpeed;

    private float hInput;
    private float vInput; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
