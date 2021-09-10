using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   
    public GameObject tank;
    
    private Vector3 offset = new Vector3(0,50,-80);

    // Update is called once per frame
    
    void Update()
    {
        //set the cameras position to the players(tank) position
        transform.position = tank.transform.position + offset;
    }
}
