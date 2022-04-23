using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damage = 30;

    private PlayerHealth target;
    
    private void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    private void AttackHitEvent()
    {
        if (target == null) { return; }

        target.TakeDamage(damage);
        target.GetComponent<DisplayDamage>().ShowDamageImpact();
    }
}
