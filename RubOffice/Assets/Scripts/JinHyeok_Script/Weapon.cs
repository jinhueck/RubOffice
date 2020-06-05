using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eWeaponType
{
    ShortRange,
    LongRange
}

public class Weapon : MonoBehaviour
{
    public float attackDamage;
    public float coolTime;
    public float distance;
    public eWeaponType eWeaponType;
    public Transform attackPos;

    public virtual void Attack() { }
    public virtual void SetAttackDirection(Vector3 dir) { }
}
