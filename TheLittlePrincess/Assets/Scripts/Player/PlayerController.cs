using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Transition))]
public class PlayerController : MonoBehaviour
{
    private Vector2 input;
    private CharacterController characterController;
    private Vector3 direction;
    private Transition transition;

    public float speed = 5f;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    private float gravity = -9.81f;
    public float gravityMultiplier = 3.0f;
    private float velocity;

    public float jumpPower;

    private bool IsGrounded() => characterController.isGrounded;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        transition = GetComponent<Transition>();
        transform.position.Set(transform.position.x, 0, transform.position.z);
    }

    private void Update()
    {
        ApplyGravity();
        ApplyRotation();
        ApplyMovement();
    }

    private void ApplyGravity()
    {
        if (IsGrounded() && velocity < 0.0f)
        {
            velocity = -1.0f;
        }
        else
        {
            velocity += gravity * gravityMultiplier * Time.deltaTime;
        }
        
        direction.y = velocity;
    }

    private void ApplyRotation()
    {
        if (input.magnitude == 0.0f) return;

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }

    private void ApplyMovement()
    {
        characterController.Move(direction * speed * Time.deltaTime);
    }

    public void Move(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
        direction = new Vector3(input.x, 0f, input.y);

        bool playAnim = input.x != 0 || input.y != 0;
        transition.Walk(playAnim);
    }

    public void Run(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            transition.Run(false);
            speed /= 2;
            return;
        }
        if (!context.started) return;

        speed *= 2;
        transition.Run(true);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            transition.Jump(false);
            return;
        }
        if (!context.started) return;
        if (!IsGrounded()) return;

        velocity += jumpPower;
        transition.Jump(true);
    }

    public void Crouch(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            transition.Crouch(false);
            return;
        }
        if (!context.started) return;

        transition.Crouch(true);
    }

    public void Dance(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            transition.Dance(false);
            return;
        }
        if (!context.started) return;

        transition.Dance(true);
    }

    public void ChangePosition(Vector3 position)
    {
        this.transform.position = position;
    }

    public Vector3 GetPosition()
    {
        return this.transform.position;
    }
}
