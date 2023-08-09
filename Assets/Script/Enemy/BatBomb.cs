using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBomb : EnemyFly
{
    public Transform leftLimit;
    public Transform rightLimit;
    [HideInInspector]
    public Transform target;
    private float direction = -1f;
    public Transform bombPoint;

    public GameObject bomb;

    private float nextAttackTime;
    public float attackRate = 1f;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void FixedUpdate()
    {
        Flip();
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        if (nextAttackTime < Time.time)
        {
            Instantiate(bomb, bombPoint.transform.position, Quaternion.identity);
            nextAttackTime = Time.time + attackRate;
        }
    }

    private void Flip()
    {
        if (transform.position.x < leftLimit.position.x)
        {
            direction *= -1;
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
        }
        else if (transform.position.x > rightLimit.position.x)
        {
            direction *= -1;
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
        }
    }

    public override void HurtSequence()
    {
        anim.SetTrigger("Hurt");
    }

    public override void DeathSequence()
    {
        anim.SetTrigger("Death");
        speed = 0;
    }
}
