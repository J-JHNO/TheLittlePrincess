using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private Vector2 input;

    public Rigidbody rg;
    public float forwardMoveSpeed;
    public float backwardMoveSpeed;
    public float steerSpeed;

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine("waitForCountDown");
        }
    }

    // Apply physics here
    void FixedUpdate()
    {
        // Accelerate
        float speed = input.y > 0 ? forwardMoveSpeed : backwardMoveSpeed;
        if (input.y == 0) speed = 0;
        rg.AddForce(this.transform.right * speed, ForceMode.Acceleration);

        // Steer
        float rotation = input.x * steerSpeed * Time.fixedDeltaTime;
        transform.Rotate(0, rotation, 0, Space.World);
    }

    public void SetInputs(Vector2 input)
    {
        this.input = input;
    }

    private IEnumerator waitForCountDown()
    {
        forwardMoveSpeed = 0;
        steerSpeed = 0;
        yield return new WaitForSeconds(4);
        forwardMoveSpeed = 60;
        steerSpeed = 180;
    }
}
