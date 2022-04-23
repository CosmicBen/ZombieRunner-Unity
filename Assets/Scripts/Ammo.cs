using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [Serializable]
    private class AmmoSlot
    {
        public AmmoType type = AmmoType.Bullets;
        public int amount = 10;
    }

    [SerializeField] private List<AmmoSlot> ammoSlots = new List<AmmoSlot>();

    public int GetCurrentAmmo(AmmoType type)
    {
        AmmoSlot ammoSlot = GetAmmoSlot(type);

        if (ammoSlot != null)
        {
            return ammoSlot.amount;
        }

        return 0;
    }

    public void IncreaseCurrentAmmo(AmmoType ammoType, int ammoAmount)
    {
        AmmoSlot ammoSlot = GetAmmoSlot(ammoType);

        if (ammoSlot != null)
        {
            ammoSlot.amount += ammoAmount;
        }
    }

    public void ReduceCurrentAmmo(AmmoType ammoType, int ammoAmount = 1)
    {
        AmmoSlot ammoSlot = GetAmmoSlot(ammoType);

        if (ammoSlot != null)
        {
            ammoSlot.amount -= ammoAmount;
        }
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.type == ammoType)
            {
                return slot;
            }
        }

        return null;
    }
}
