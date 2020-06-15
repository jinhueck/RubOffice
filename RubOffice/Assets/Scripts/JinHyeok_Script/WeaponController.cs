using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponController : MonoBehaviour
{
    public List<Weapon> nearWeaponList = new List<Weapon>();
    public Weapon nearestWeapon;

    public Weapon[] weaponArray = new Weapon[3];
    public Weapon selectWeapon;

    public float presentAttackCool;
    public Vector3 attackDirection;

    public void UpdateWeapon(Vector2 playerPos)
    {
        if (nearWeaponList.Count == 0)
        {
            nearestWeapon = null;
            return;
        }

        float minDistance = -1;
        Weapon minDistanceWeapon = null;
        foreach (var mNearWeapon in nearWeaponList)
        {
            Vector2 distanceDirection = (Vector2)mNearWeapon.transform.position - playerPos;
            float distanceCheck = distanceDirection.sqrMagnitude;
            if (minDistance == -1 || minDistance > distanceCheck)
            {
                minDistance = distanceCheck;
                minDistanceWeapon = mNearWeapon;
            }
        }
        nearestWeapon = minDistanceWeapon;
    }

    public void SetWeapon(int pos)
    {
        if(pos >= weaponArray.Length)
        {
            Debug.LogError("Weapon Array's Length is shorter than Pos");
            return;
        }

        for(int i = 0; i < weaponArray.Length; i++)
        {
            weaponArray[i].gameObject.SetActive(i == pos);
        }

        Weapon nWeapon = weaponArray[pos];
        if(nWeapon == null)
        {
            Debug.Log("Weapon is null");
            return;
        }

        if (selectWeapon != weaponArray[pos])
            selectWeapon = weaponArray[pos];
    }

    public void AddWeapon(int pos)
    {
        if (nearestWeapon == null)
            return;

        var deleteWeapon = weaponArray[pos];
        if (deleteWeapon != null)
            deleteWeapon.transform.parent = null;

        weaponArray[pos] = nearestWeapon;
        SetWeapon(pos);
    }

    public void SetWeaponPos(Vector3 playerPos, float playerBodyDistance, Vector3 direction)
    {
        attackDirection = direction.normalized;
        selectWeapon.transform.position = playerPos + direction * playerBodyDistance;

        Vector2 weaponPos = selectWeapon.transform.position;
        float angle = Mathf.Atan2(weaponPos.y - playerPos.y, weaponPos.x - playerPos.x) * Mathf.Rad2Deg;
        selectWeapon.transform.rotation = Quaternion.AngleAxis(angle + 180, Vector3.forward);
    }

    public void CheckAttackCoolTime()
    {
        if (presentAttackCool <= selectWeapon.coolTime)
        {
            presentAttackCool += Time.deltaTime;
            return;
        }
        presentAttackCool = 0;
        AttackFunc();
    }

    private void AttackFunc()
    {
        if(selectWeapon == null)
        {
            Debug.LogError("Weapon is Empty");
        }
        selectWeapon.SetAttackDirection(attackDirection);
        selectWeapon.Attack();
    }

}