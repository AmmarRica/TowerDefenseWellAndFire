using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 6;
    public float rotationSpeed = 450;
    public GunController gun;

    Rigidbody rigidbody;
    Camera ViewCamera;
    Vector3 velocity;

    private Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        ViewCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ControlWASD();
        ControlMouse();
        //ControlWASDOnly()

        if (Input.GetButtonDown("shoot"))
        {
            if (gun == null) { Debug.Log("no gun found"); }
            else
            {
                gun.Shoot();
                gun.isFiring = true;
            }
        }
        if (Input.GetButtonUp("shoot") && gun)
        {
            gun.isFiring = false;
        }
    }

    void ControlMouse()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = ViewCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, ViewCamera.transform.position.y - transform.position.y));
        targetRotation = Quaternion.LookRotation(mousePos - new Vector3(transform.position.x, 0, transform.position.z));
        transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);


        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")); //.normalized * moveSpeed;
        Vector3 motion = input;
        motion *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1) ? 0.7f : 1; //I have no idea what this is
        motion += Vector3.up * 8;
    }

    void ControlWASD()
    {
        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * moveSpeed;

        //if (velocity != Vector3.zero)
        //{
        //    transform.rotation = Quaternion.LookRotation(velocity);
        //}
    }

    void ControlWASDOnly()
    {
        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * moveSpeed;

        if (velocity != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(velocity);
        }
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
    }
}
