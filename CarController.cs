using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public Rigidbody motorRb;

    private float moveInput;
    private float turnInput;

    public float forwardSpeed;
    public float reverseSpeed;
    public float turnSpeed;


    void Start()
    {
        motorRb.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");

        moveInput *= moveInput>0 ? forwardSpeed : reverseSpeed;

        transform.position = motorRb.transform.position;

        float newRotation = turnInput * turnSpeed* Time.deltaTime * Input.GetAxisRaw("Vertical");
        transform.Rotate(0, newRotation, 0, Space.World);
    }

    private void FixedUpdate()
    {
        motorRb.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
    }
}
