using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;

    protected Rigidbody2D rb;
    protected Animator anim;
    public GameObject TextPoint;//Text sát thương


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    public void TakeDamge(float damage)
    {
        GameObject floatingText = Instantiate(TextPoint,transform.position,Quaternion.identity) as GameObject; //Clone text
        floatingText.transform.GetChild(0).GetComponent<TextMesh>().text = "" + damage;//Ghi chỉ số cho text
        health -= damage;
        HurtSequence();
        if (health <= 0)
        {

            DeathSequence();
        }
    }


    public virtual void HurtSequence()
    {

    }

    public virtual void DeathSequence()
    {

    }
}
