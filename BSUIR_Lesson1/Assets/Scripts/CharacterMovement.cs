using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : Character
{
    [SerializeField] float speed = 100;
    float gravity = 9.8f;
    Vector2 direction;
    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void SetMovementDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    void Update()
    {
        Vector3 movement = Vector3.ClampMagnitude(new Vector3(direction.x, 0, direction.y) * speed, speed);
        movement.y = -gravity;
        movement = transform.TransformDirection(movement) * Time.deltaTime;
        characterController.Move(movement);
    }
}
