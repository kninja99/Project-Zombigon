using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // default moving speed for players
    [SerializeField] private float moveSpeed = 12f;
    [SerializeField] private float jumpHeight = 2f;
    // controller reference for the player movement
    [SerializeField] private CharacterController controller;
    // falling physics 
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float gravity = -9.81f;
    // Ground Checker
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = .4f;
    [SerializeField] private LayerMask groundMask;

    private bool isGrounded;

    private void Start()
    {
        isGrounded = false;
    }

    // Update is called once per frame
    private void Update()
    {
        // calculating if grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        // getting input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // actual movement
        Vector3 moveDir = transform.right * x + transform.forward * z;
        controller.Move(moveDir * moveSpeed * Time.deltaTime);
        // Jump Check
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        // gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
