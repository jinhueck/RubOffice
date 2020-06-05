using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public JoyStickController joyStickController;
    public WeaponController weaponController;

    public PlayerInfo playerInfo;
    public float playerBodyDistance;
    //--------------------------------------------------------------------------

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        MoveFunc();
        AttackFunc();
    }

    //--------------------------------------------------------------------------

    public void Init()
    {
        playerInfo.Init();
        playerBodyDistance = playerInfo.collider2D.size.x * 0.5f;
    }

    public void MoveFunc()
    {
        var moveDir = joyStickController.MoveDirection() * playerInfo.speed;
        playerInfo.rigidbody.velocity = moveDir;
    }

    public void AttackFunc()
    {
        var AttackDir = joyStickController.AttackDirection();
        weaponController.SetWeaponPos(playerInfo.transform.position, playerBodyDistance, AttackDir);
        if (AttackDir == Vector2.zero)
            return;
        weaponController.CheckAttackCoolTime();
    }

    
}

