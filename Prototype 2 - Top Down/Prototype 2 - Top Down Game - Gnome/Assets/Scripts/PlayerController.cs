using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15.0f;
    public float turnSpeed = 50.0f;
    private float hInput;
    private float vInput;

    public float xRange = 9.17f;
    public float yRange = 4.45f;

    // Update is called once per frame
    void Update()
    {
        //Gathering keyboard input for movement
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        //Makes the pc rotate left and right
        transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime * hInput);
        //Makes the pc move forward and back
        transform.Translate(Vector3.up * speed * Time.deltaTime * vInput);
         //Creates right wall
         if(transform.position.x > xRange)
         {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
         }
         //Creates left wall
         if(transform.position.x < -xRange)
         {
           transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
         }
         //Creates top wall
         if(transform.position.y > yRange)
         {
             transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
         }
         //Creates bottom wall
         if(transform.position.y < -yRange)
         {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
         }
    }
}
