using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Weapon weapon;
    public float presentAttackCool;
    public Vector3 attackDirection;

    public void SetWeaponPos(Vector3 playerPos, float playerBodyDistance, Vector3 direction)
    {
        attackDirection = direction.normalized;
        weapon.transform.position = playerPos + direction * playerBodyDistance;

        Vector2 weaponPos = weapon.transform.position;
        float angle = Mathf.Atan2(weaponPos.y - playerPos.y, weaponPos.x - playerPos.x) * Mathf.Rad2Deg;
        weapon.transform.rotation = Quaternion.AngleAxis(angle + 180, Vector3.forward);
    }

    public void CheckAttackCoolTime()
    {
        if (presentAttackCool <= weapon.coolTime)
        {
            presentAttackCool += Time.deltaTime;
            return;
        }
        presentAttackCool = 0;
        AttackFunc();
    }

    private void AttackFunc()
    {
        if(weapon == null)
        {
            Debug.LogError("Weapon is Empty");
        }
        weapon.SetAttackDirection(attackDirection);
        weapon.Attack();
    }
}
