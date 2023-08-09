using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public int hitsToDestroy;//số lượt đánh
    protected Animator anim;

    protected void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void HitDestructible()
    {
        hitsToDestroy -= 1;
        Hit();
        if (hitsToDestroy <= 0)
        {
            Destroy();
            
        }
    }

    public void CleanUp()
    {
        Destroy(gameObject);
    }
    public virtual void Hit()
    {

    }

    public virtual void Destroy()
    {

    }
}
