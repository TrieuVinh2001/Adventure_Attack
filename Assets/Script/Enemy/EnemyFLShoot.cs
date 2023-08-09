using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFLShoot : EnemyFly
{
    private Transform player;

    public float shootingRange;
    public GameObject bulletParent;
    public GameObject bullet;
    public float fireRate = 1f;
    private float nextFireTime;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer>shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= shootingRange && nextFireTime<Time.time)//Time.time là thời gian hiện tại
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;//cộng thêm fireRate nghĩa là đợi thêm 1 lúc nữa để bắn
        }

        //dùng để flip (chuyển hướng về player)
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x < player.position.x)
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
        Gizmos.DrawWireSphere(transform.position, shootingRange);
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
}
