using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : EnemyFly
{
    private Transform player;
    public float attackRange=2f;
    private float nextAttackTime;
    public float attackRate = 2f;

    public float forceX = 5f;
    public float forceY = 3f;
    public float duration = 0.15f;
    public float damage = 10;
    //private PlayerStats playerStats;
    private PlayerMoveController playerMove;

    public CircleCollider2D poly;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;//Tìm lấy vị trí của player
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);//tính khoảng cách giữa player và quái

        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > attackRange)//so sánh khoảng cách
        {
            anim.SetTrigger("Flying");
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);//từ vị trí hiện tại đi đến vị trí player với vận tốc speed
        }
        else if (distanceFromPlayer < attackRange &&  nextAttackTime < Time.time)
        {
            anim.SetTrigger("Attack");
            nextAttackTime = Time.time + attackRate;
        }

        //dùng để flip (chuyển hướng về player)
        Vector3 rotation = transform.eulerAngles;//Phép quay ngược theo góc
        if (transform.position.x < player.transform.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }

        transform.eulerAngles = rotation;
    }


    private void OnDrawGizmosSelected()//Vẽ
    {
        Gizmos.color = Color.green;//mùa xanh
        Gizmos.DrawWireSphere(transform.position, lineOfSite);//Hình tròn , tại vị trí với rộng lineOfSite
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public override void HurtSequence()
    {
        anim.SetTrigger("Hurt");
    }

    public override void DeathSequence()
    {
        anim.SetTrigger("Death");
        speed = 0;
        //GetComponent<CapsuleCollider2D>().enabled = false;
        //GetComponentInChildren<PolygonCollider2D>().enabled = false;
        //rb.gravityScale = 0;//Trọng lực
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        playerStats = collision.GetComponentInChildren<PlayerStats>();
    //        playerStats.TakeDamage(damage);
    //        SpecialAttack();
    //    }
    //}
    //public void SpecialAttack()//bị bật lại khi tấn công
    //{
    //    playerMove = playerStats.GetComponentInParent<PlayerMoveController>();
    //    StartCoroutine(playerMove.KnockBack(forceX, forceY, duration, transform));
    //}

    public void OnAttack()
    {
        poly.enabled = true;
        StartCoroutine(OffAttack());
    }

    private IEnumerator OffAttack()
    {
        yield return new WaitForSeconds(0.2f);
        poly.enabled = false;
    }
}
