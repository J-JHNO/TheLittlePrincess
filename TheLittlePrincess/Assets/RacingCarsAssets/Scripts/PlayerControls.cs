using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControls : MonoBehaviour
{
    private float inputX;
    private float inputY;
    private Vector2 input;

    public UnityEvent<Vector2> onInput;

    // Start is called before the first frame update
    void Start()
    {
        input = new Vector2(inputX, inputY).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        inputY = Input.GetAxis("Vertical");
        inputX = Input.GetAxis("Horizontal");

        input.Set(inputX, inputY);

        onInput.Invoke(input);
    }
}
