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

    //SO File
    public WeaponData weaponData;

    //SO 파일에서 받아오는 데이터
    public float attackDamage;
    public float coolTime;
    public float attackRange;
    public eWeaponType eWeaponType;

    //들고 있어야 할 데이터
    public Transform attackPos;

    private void Start()
    {
        InitData();
    }

    public void InitData()
    {
        if (weaponData == null)
        {
            Debug.LogError("This Weapon Doesn't have a WeaponData(Scriptable Object)");
            return;
        }
        attackDamage = weaponData.attackDamage;
        coolTime = weaponData.coolTime;
        attackRange = weaponData.attackRange;
        eWeaponType = weaponData.eWeaponType;
    }

    public virtual void Attack() { }
    public virtual void SetAttackDirection(Vector3 dir) { }
}
