using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public void Init(Vector2 direction, float speed)
    {
        rigidbody.velocity = direction * speed;
    }
}
