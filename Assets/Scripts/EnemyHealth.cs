﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float hitPoints = 100.0f;
    private bool isDead = false;

    public bool IsDead { get { return isDead; } }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken", SendMessageOptions.DontRequireReceiver);
        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) { return; }

        isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
    }
}