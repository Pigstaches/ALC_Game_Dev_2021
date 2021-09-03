using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComtroller : MonoBehaviour
{
    private float speed;
    private float turnspeed;

    private float hInput;
    private float vInput; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        //moves tank forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime * vInput);
        transform.Translate(Vector3.right * speed * Time.deltaTime * hInput);
    }
}
