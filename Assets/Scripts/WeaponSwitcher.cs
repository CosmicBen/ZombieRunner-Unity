using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private int currentWeaponIndex = 0;

    private void Start()
    {
        SetWeaponActive();
    }

    private void Update()
    {
        int previousWeaponIndex = currentWeaponIndex;

        ProcessKeyInput();
        ProcessScrollWheel();

        if (previousWeaponIndex != currentWeaponIndex)
        {
            SetWeaponActive();
        }
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeaponIndex = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeaponIndex = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeaponIndex = 2;
        }
    }

    private void ProcessScrollWheel()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll < 0)
        {
            currentWeaponIndex = (currentWeaponIndex + 1) % transform.childCount;
        }
        else if (scroll > 0)
        {
            currentWeaponIndex = (transform.childCount - 1 + currentWeaponIndex) % transform.childCount;
        }
    }

    private void SetWeaponActive()
    {
        for (int weaponIndex = 0; weaponIndex < transform.childCount; ++weaponIndex)
        {
            Transform weapon = transform.GetChild(weaponIndex);

            if (weaponIndex == currentWeaponIndex)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
        }
    }
}
