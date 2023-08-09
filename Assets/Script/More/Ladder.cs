using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private PlayerMoveController pMC;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pMC = collision.GetComponentInParent<PlayerMoveController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       
            pMC.onLadders = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pMC.ExitLadder();
    }
}
