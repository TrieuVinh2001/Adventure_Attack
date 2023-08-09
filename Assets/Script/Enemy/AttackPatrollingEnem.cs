using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPatrollingEnem : EnemyAttack
{//của Attack->DogEnemy
    PlayerMoveController playerMove;
    public float forceX;
    public float forceY;
    public float duration;

    public override void SpecialAttack()
    {
        playerMove = playerStats.GetComponentInParent<PlayerMoveController>();
        StartCoroutine(playerMove.KnockBack(forceX,forceY,duration,transform.parent));
    }
}
