using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 10;
    public float gravity = -9.81f;

    Vector3 velocity;

    public Transform check;
    float groundDistance = .2f;
    public LayerMask groundMask;
    bool isGrounded;

    public float jump = 4f;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(check.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
