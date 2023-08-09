using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    //PlayerMoveController playerMove;
    private GameObject target;
    public float speed;
    private Rigidbody2D bulletRB;

    //public float forceX = 5f;
    //public float forceY = 3f;
    //public float duration = 0.15f;
    public float damage = 5;
    private PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);//Hủy sau 2 giây
    }

    private void Update()
    {
        //dùng để flip (chuyển hướng về player)
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.transform.position.x)
        {
            rotation.y = 0f;
        }
        else
        {
            rotation.y = 180f;
        }

        transform.eulerAngles = rotation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerStats = collision.GetComponentInChildren<PlayerStats>();
            playerStats.TakeDamage(damage);
            //SpecialAttack();
        }
    }
    //public void SpecialAttack()//bị bật lại khi tấn công
    //{
    //    playerMove = playerStats.GetComponentInParent<PlayerMoveController>();
    //    StartCoroutine(playerMove.KnockBack(forceX, forceY, duration, transform));
    //}
}
