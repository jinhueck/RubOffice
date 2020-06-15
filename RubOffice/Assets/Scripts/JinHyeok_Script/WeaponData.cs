using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "WeaponData", menuName = "RubSOFile/Weapon", order = 2)]
public class WeaponData : ScriptableObject
{
    public float attackDamage;
    public float coolTime;
    public float attackRange;
    public eWeaponType eWeaponType;
}
