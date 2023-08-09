using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public float damage = 10f;
    private Rigidbody2D rb;
    private Animator anim;

    public GameObject bulletEffect; //gameObject có animation đạn nổ

    public int destructibleLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        destructibleLayer = LayerMask.NameToLayer("Destructible");//Lấy số thứ tự của Layer tên Destructible
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * bulletSpeed;//đạn di chuyển khi được tạo ra
        StartCoroutine(DestroyTime());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        Enemy enemy = other.GetComponent<Enemy>();
        if(enemy != null)//Nếu có chạm enemy
        {
            enemy.transform.GetComponent<Enemy>();
            enemy.TakeDamge(damage);
        }
        EnemyFly enemyfly = other.GetComponent<EnemyFly>();
        if (enemyfly != null)//Nếu có chạm enemy
        {
            enemyfly.transform.GetComponent<EnemyFly>();
            enemyfly.TakeDamge(damage);
        }
        Boss boss = other.GetComponent<Boss>();
        if (enemyfly != null)//Nếu có chạm enemy
        {
            boss.transform.GetComponent<Boss>();
            boss.TakeDamge(damage);
        }
        if (other.gameObject.layer == destructibleLayer)//Nếu chạm layer này thì
        {
            other.GetComponent<Destructible>().HitDestructible();
        }
        
        Instantiate(bulletEffect,transform.position, Quaternion.identity);//dùng để tạo animation tại vị trí bắn trúng
        Destroy(gameObject);
        //anim.SetTrigger("BulletDestroy");

    }
    public void DestroyBullet()//xóa đạn , gắn ở animation bulletDestroy
    {
        Destroy(gameObject);
    }


    private IEnumerator DestroyTime()//thời gian xóa đạn
    {
        yield return new WaitForSeconds(2f);//sau 2 giây tự xóa
        Destroy(gameObject);
    }

}
