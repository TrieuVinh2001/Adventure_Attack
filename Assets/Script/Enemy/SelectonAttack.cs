using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectonAttack : MonoBehaviour
{
    PlayerMoveController playerMove;
    public float forceX;
    public float forceY;
    public float duration;
    public float damage;
    private PlayerStats playerStats;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerStats = collision.GetComponentInChildren<PlayerStats>();
            playerStats.TakeDamage(damage);
            SpecialAttack();
        }

    }


    public  void SpecialAttack()
    {
        playerMove = playerStats.GetComponentInParent<PlayerMoveController>();
        StartCoroutine(playerMove.KnockBack(forceX, forceY, duration, transform.parent));
    }
}
