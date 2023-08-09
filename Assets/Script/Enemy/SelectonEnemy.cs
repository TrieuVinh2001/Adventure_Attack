using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectonEnemy : Enemy
{
    //public Transform rayCast;
    //public LayerMask rayCastMask;//Layer cần phát hiện
    //public float rayCastLenght;
    public float attackDistance;
    public float moveSpeed;
    public float timer;//Thời gian nghỉ sau tấn cống
    public PolygonCollider2D poly;
    public Transform leftLimit;
    public Transform rightLimit;
    [HideInInspector]public Transform target;
    [HideInInspector]public bool inRange;//Phát hiện kẻ thù,bool k cho giá trị thì mặc định là false
    public GameObject hotZone;
    public GameObject triggerArea;

    //private RaycastHit2D hit;
    //private Animator anim;
    private float distance;
    private bool attackMode;
    private bool cooling;//Nghỉ sau khi tấn công
    private float intTimer;

    void Awake()
    {
        SelectonTarget();
        intTimer = timer;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!attackMode)
        {
            Move();
        }

        if (!InsideofLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Selecton_Attack"))
        {
            SelectonTarget();
        }

        if (inRange)
        {
            EnemyLogic();
        }
    }


    private void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);//Khoảng cách giữa quái và player

        if (distance > attackDistance)//Nếu khoảng cách lớn hơn khoảng cách tấn công(nghĩa là trong vùng k có player)
        {
            //Move();
            StopAttack();
        }
        else if(attackDistance>=distance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            Cooldown();//thòi gian nghỉ sẽ giảm dần
            anim.SetBool("Attack", false);
        }
    }

    private void Move()
    {
        anim.SetBool("CanWalk", true);
        if (!anim.GetNextAnimatorStateInfo(0).IsName("Selecton_Attack"))//nói chung là nếu animation này k hoạt động thì
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);//tạo vector có vị trí player , y thì k cần
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            //vị trí thay đổi , đi từ vị trí hiện tại là tranform.position đến vị trí Player là targetPosition với vận tốc moveSpeed
        }
    }

    private void Attack()
    {
        timer = intTimer;//đặt lại thời gian player nhập phạm vi tấn công
        attackMode = true;//kiểm tra xem có tấn công k

        anim.SetBool("CanWalk", false);
        anim.SetBool("Attack", true);
    }

    private void Cooldown()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    private void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }


    //public void TriggerCooling()//Khi kết thúc animation thì sẽ thực hiện, liên quan đến thời gian nghỉ
    //{
        
    //    Debug.Log("1");
    //    poly.enabled = false;
    //    Debug.Log("1");
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
        cooling = true;
    }

    private bool InsideofLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    public void SelectonTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

        if (distanceToLeft > distanceToRight)
        {
            target = leftLimit;
        }
        else
        {
            target = rightLimit;
        }
        Flip();
    }

    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }

        transform.eulerAngles = rotation;
    }

    public override void HurtSequence()
    {
        anim.SetTrigger("Hurt");
    }

    public override void DeathSequence()
    {
        anim.SetTrigger("Death");
        moveSpeed = 0;
        //GetComponent<CapsuleCollider2D>().enabled = false;
        //GetComponentInChildren<PolygonCollider2D>().enabled = false;
        //rb.gravityScale = 0;//Trọng lực
    }

    public void DestroySelecton()
    {
        Destroy(gameObject);
    }
}
