using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Boss
{
    public float damage;
    private Transform player;

    public float attackRange;
    private float nextAttackTime;
    public float attackRate = 2f;

    public PolygonCollider2D poly;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;//Tìm lấy vị trí của player
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);//tính khoảng cách giữa player và quái

        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > attackRange)//so sánh khoảng cách
        {
            anim.SetTrigger("Run");
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);//từ vị trí hiện tại đi đến vị trí player với vận tốc speed
        }
        else if (distanceFromPlayer < attackRange && nextAttackTime < Time.time)
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
        door.SetActive(true);
    }

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
