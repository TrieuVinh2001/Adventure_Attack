using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float damage = 15f;
    private PlayerStats playerStats;
    public float bombSpeed;
    private Rigidbody2D rb;
    private Animator anim;

    private int ground;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ground = LayerMask.NameToLayer("Ground");
    }

    private void Update()
    {
        rb.velocity = new Vector3(0,-1,0) * bombSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("Explosion");
            bombSpeed = 0f;
            playerStats = collision.GetComponentInChildren<PlayerStats>();
            playerStats.TakeDamage(damage);
            Destroy(gameObject, 0.2f);
        }

        else if (collision.gameObject.layer==ground)
        {
            anim.SetTrigger("Explosion");
            bombSpeed = 0f;
            Destroy(gameObject, 0.2f);
        }
        else
        {
            
        }

        
    }
}
