using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float speed = 50;
    [SerializeField] float jumpSpeed = 7;
    [SerializeField] float gravityMultiplier = 1.5f;
    Vector2 direction;
    CharacterController characterController;
    Vector3 movement;
    bool prevFrameIsGrounded;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    
    public void SetMovementDirection(Vector2 direction)
    {
        this.direction = direction.normalized;
    }

    public void Jump()
    {
        if (characterController.isGrounded)
        {
            movement.y = jumpSpeed;
        }
    }

    void Update()
    {
        if (!characterController.isGrounded)
        {
            movement.y += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        }
        else if(movement.y < 0)
        {
            movement.y = 0;
        }
        movement = new Vector3(direction.x * speed, movement.y, direction.y * speed);
        movement = transform.TransformDirection(movement);
        if (GetComponent<NavMeshAgent>())
            return;
        characterController.Move(movement * Time.deltaTime);
    }
}
