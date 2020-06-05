using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickController : MonoBehaviour
{
    public VariableJoystick MoveJoyStick;
    public VariableJoystick AttackJoyStick;

    public Vector2 MoveDirection()
    {
        Vector2 direction = Vector2.up * MoveJoyStick.Vertical + Vector2.right * MoveJoyStick.Horizontal;
        return direction;
    }

    public Vector2 AttackDirection()
    {
        Vector2 direction = Vector2.up * AttackJoyStick.Vertical + Vector2.right * AttackJoyStick.Horizontal;
        return direction;
    }
}
