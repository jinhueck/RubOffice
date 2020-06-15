using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetective : MonoBehaviour
{
    public WeaponController weaponController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            var nWeapon = collision.GetComponent<Weapon>();
            weaponController.nearWeaponList.Add(nWeapon);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            var nWeapon = collision.GetComponent<Weapon>();
            weaponController.nearWeaponList.Remove(nWeapon);
        }
    }
}
