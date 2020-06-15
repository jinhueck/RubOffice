using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public JoyStickController joyStickController;
    public WeaponController weaponController;
    public ButtonController buttonController;

    public PlayerInfo playerInfo;
    public float playerBodyDistance;
    //--------------------------------------------------------------------------

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        weaponController.UpdateWeapon(playerInfo.transform.position);

        MoveFunc();
        AttackFunc();
    }

    //--------------------------------------------------------------------------

    public void Init()
    {
        if (PlayerManager.instance == null)
            PlayerManager.instance = this;

        playerInfo.Init();
        playerBodyDistance = playerInfo.collider2D.size.x * 0.5f;

        buttonController.Init();
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

