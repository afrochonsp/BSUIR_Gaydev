using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : Character
{
    [SerializeField] float speed = 100;
    float gravity = 9.8f;
    Vector2 direction;
    CharacterController characterController;
    Rigidbody rigidbody;
    Vector3 movement;
    float movementY;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody>();
    }
    
    public void SetMovementDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    public void Jump()
    {
        if (characterController.isGrounded)
        {
            movementY = 120f;
        }
        
    }



    void Update()
    {
        movement = Vector3.ClampMagnitude(new Vector3(direction.x, movement.y, direction.y) * speed, speed);
        if (characterController.isGrounded == false)
        {
        movementY -= gravity / 4;
        }
        movement.y = movementY;
        movement = transform.TransformDirection(movement) * Time.deltaTime;
        characterController.Move(movement);
    }
}
