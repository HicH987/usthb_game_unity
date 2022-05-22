using System;
using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContollerLevel1 : MonoBehaviour
{
    private InputMaster controls;
    private float moveSpeed = 20f;
    private Vector3 velocity;
    private float gravity = -9.81f;
    private Vector2 move;
    private float jumpHeight = 8f;
    private CharacterController controller;
    public Transform ground;
    public float distanceToGround = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    void Awake()
    {
        controls = new InputMaster();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Grav();
        PlayerMouvement();
        Jump();
    }

    private void Grav()
    {
        isGrounded = Physics.CheckSphere(ground.position, distanceToGround, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); 
    }


    private void PlayerMouvement()
    {
        move = controls.Player.Movement.ReadValue<Vector2>();
        Vector3 movement = (move.y * transform.forward) + (move.x * transform.right);
        controller.Move(movement * moveSpeed * Time.deltaTime); 
    }

    private void Jump()
    {
        // UnityEngine.Debug.Log("JUMP..");
        bool isGrounded = Physics.Raycast(ground.position, Vector3.down, 1.0f, groundMask);
        if(controls.Player.Jump.triggered && isGrounded)
        {
            // UnityEngine.Debug.Log("JUMP..");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
