﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public VariableJoystick variableJoystick2;
    public Rigidbody rb;

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        Vector3 direction2 = Vector3.forward * variableJoystick2.Vertical + Vector3.right * variableJoystick2.Horizontal;
        rb.AddForce(direction2 * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }
}