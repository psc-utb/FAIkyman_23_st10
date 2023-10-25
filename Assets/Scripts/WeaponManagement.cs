using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagement : MonoBehaviour
{
    [SerializeField]
    GameObject weapon;

    public void ActivateWeapon()
    {
        weapon?.SetActive(true);
    }

    public void DeactivateWeapon()
    {
        weapon?.SetActive(false);
    }
}
