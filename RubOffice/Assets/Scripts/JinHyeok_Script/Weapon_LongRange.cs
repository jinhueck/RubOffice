using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_LongRange : Weapon
{
    public Bullet bullet;
    public Vector3 attackDir;
    public float attackSpeed;

    public override void Attack() {
        var nBullet = Instantiate(bullet, attackPos.position, Quaternion.identity);
        nBullet.Init(attackDir, attackSpeed);
    }

    public override void SetAttackDirection(Vector3 dir) {
        attackDir = dir;
    }
}
