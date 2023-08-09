using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuNhin : Enemy
{
   

    public override void HurtSequence()
    {
        anim.SetTrigger("Hurt");
    }

    //public override void DeathSequence()
    //{
    //    //anim.SetTrigger("Death");
    //    //GetComponent<CapsuleCollider2D>().enabled = false;
    //    //GetComponentInChildren<PolygonCollider2D>().enabled = false;
    //    //rb.gravityScale = 0;//Trọng lực
    //}
}
