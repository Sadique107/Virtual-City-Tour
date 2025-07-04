﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerAndroid : MonoBehaviour
{
    CharacterController characterController;
    public VariableJoystick variableJoystick;
    public float MovementSpeed = 1;
    public float Gravity = 9.8f;
    private float velocity = 0;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // player movement - forward, backward, left, right
        float horizontal = variableJoystick.Horizontal * MovementSpeed;
        float vertical = variableJoystick.Vertical * MovementSpeed;
        characterController.Move((transform.right * horizontal + transform.forward * vertical) * Time.deltaTime);

        // Gravity
        if (characterController.isGrounded)
        {
            velocity = 0;
        }
        else
        {
            velocity -= Gravity * Time.deltaTime;
            characterController.Move(new Vector3(0, velocity, 0));
        }
    }
}
