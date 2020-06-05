using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public float hp;
    public float damage;
    public float speed;
    public float attackSpeed;
    
    public BoxCollider2D collider2D;
    public Rigidbody2D rigidbody;
    public GameObject weapon;

    public void Init()
    {
        hp = 100f;
        damage = 10f;
        speed = 5f;
        attackSpeed = 0.5f;

        if (collider2D == null)
            collider2D = GetComponent<BoxCollider2D>();
        if (rigidbody == null)
            rigidbody = GetComponent<Rigidbody2D>();
    }
}