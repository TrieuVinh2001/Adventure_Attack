using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage;
    protected PlayerStats playerStats;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerStats = collision.GetComponent<PlayerStats>();
        playerStats.TakeDamage(damage);

        SpecialAttack();
    }

    public virtual void SpecialAttack()
    {

    }
}
