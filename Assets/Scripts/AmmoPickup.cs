using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private AmmoType ammoType;
    [SerializeField] private int ammoAmount = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Ammo playerAmmo = other.gameObject.GetComponent<Ammo>();
            
            if (playerAmmo != null)
            {
                playerAmmo.IncreaseCurrentAmmo(ammoType, ammoAmount);
            }

            Destroy(gameObject);
        }
    }
}
