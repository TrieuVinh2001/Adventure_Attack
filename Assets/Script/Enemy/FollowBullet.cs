using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBullet : MonoBehaviour
{
    public float speed = 5f;
    private Transform player;
    private Rigidbody2D bulletRB;

    //public float forceX =5f;
    //public float forceY=3f;
    //public float duration=0.15f;
    public float damage = 5;
    private PlayerStats playerStats;
    //PlayerMoveController playerMove;

    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(this.gameObject, 2);//Hủy sau 2 giây
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed*Time.deltaTime);

        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > player.position.x)
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
    //public void SpecialAttack()
    //{
    //    playerMove = playerStats.GetComponentInParent<PlayerMoveController>();
    //    StartCoroutine(playerMove.KnockBack(forceX, forceY, duration, transform));
    //}
}
