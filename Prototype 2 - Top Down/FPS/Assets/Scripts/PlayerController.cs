using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("movement")]
    public float moveSpeed;
    public float jumpForce;
    [Header("Camera")]
    public float lookSensitivity; //mouse look sensitivity
    public float maxLookX; // lowest down positiion we can look
    public float minLookX; //highest up position we can look
    private float rotX; //current x rotation of the camera
    [Header("GameObjects and Components")]
    private Camera cam;
    private Rigidbody rb;
    private Weapons weapons; 
    [Header("Stats")]
    public int curHP;
    public int maxHP;

    void Awake()
    {
        //get the components
        cam = Camera.main; 
        rb = GetComponent<Rigidbody>();
        weapons = GetComponent<Weapons>();
        //disable cursor
        Cursor.lockState = CursorLockMode.Locked;

    }

    public void TakeDamage(int damage)
    {
        curHP -= damage;
        if(curHP <= 0)
            Die();
    }

    void Die()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();

        if(Input.GetButtonDown("Jump"))
            Jump();

        if(Input.GetButton("Fire1"))
        {
            if(weapons.CanShoot())
            {
                weapons.Shoot();
            }
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        //Face directino of camera
        Vector3 dir = transform.right * x + transform.forward * z;
        //jump direction
        dir.y = rb.velocity.y;
        //move in the direction of the camera
        rb.velocity = dir;
    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(ray, 1.1f))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;
        //clamps the camera up and down rotation
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        //apply rotation to camera
        cam.transform.localRotation = Quaternion.Euler(-rotX,0,0);
        transform.eulerAngles += Vector3.up * y;
    }

    public void GiveHealth (int amountToGive)
    {
        curHP = Mathf.Clamp(curHP + amountToGive, 0, maxHP);
    }

    public void GiveAmmo (int amountToGive)
    {
        weapons.curAmmo = Mathf.Clamp(weapons.curAmmo + amountToGive, 0, weapons.maxAmmo);
    }

}
