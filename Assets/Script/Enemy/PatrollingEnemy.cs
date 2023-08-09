using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : Enemy
{//Script của DogEnemy
    public float speed;
    private int direction = -1;

    public Transform groundCheck;
    public Transform wallCheck;
    public LayerMask layerToCheck;

    private bool detectGround;
    private bool detectWall;

    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        //OnDrawGizmos();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Flip();
        rb.velocity = new Vector2(direction*speed, rb.velocity.y);
    }

    public override void HurtSequence()
    {
        anim.SetTrigger("Hurt");
    }

    public override void DeathSequence()
    {
        anim.SetTrigger("Death");
        speed = 0;
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponentInChildren<PolygonCollider2D>().enabled = false;
        rb.gravityScale = 0;//Trọng lực
    }

    private void Flip()
    {
        detectGround = Physics2D.OverlapCircle(groundCheck.position, radius, layerToCheck);
        detectWall = Physics2D.OverlapCircle(wallCheck.position, radius, layerToCheck);

        if(detectWall || detectGround == false)
        {
            direction *= -1;
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, radius);
        Gizmos.DrawWireSphere(wallCheck.position, radius);
    }
}
