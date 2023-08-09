using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{//script của Playerattack->Player
    public float attackDamage;
    private int enemyLayer;
    private int enemyFlyLayer;
    private int boss;
    private int destructibleLayer;

    // Start is called before the first frame update
    void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");//lấy thứ tự của layer này
        enemyFlyLayer = LayerMask.NameToLayer("EnemyFly");
        boss = LayerMask.NameToLayer("Boss");
        destructibleLayer = LayerMask.NameToLayer("Destructible");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == enemyLayer)
        {
            collision.GetComponent<Enemy>().TakeDamge(attackDamage);
        }

        if (collision.gameObject.layer == enemyFlyLayer)
        {
            collision.GetComponent<EnemyFly>().TakeDamge(attackDamage);
        }
        if (collision.gameObject.layer == boss)
        {
            collision.GetComponent<Boss>().TakeDamge(attackDamage);
        }

        if (collision.gameObject.layer == destructibleLayer)
        {
            collision.GetComponent<Destructible>().HitDestructible();
        }
    }
}
