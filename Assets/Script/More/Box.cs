using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Destructible
{
    public override void Hit()
    {
        anim.SetTrigger("Hit");
    }
    public override void Destroy()
    {
        anim.SetTrigger("Destroy");
    }
}
