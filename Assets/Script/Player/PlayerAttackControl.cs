using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using TMPro;

public class PlayerAttackControl : MonoBehaviour
{//của Player
    private PlayerMoveController pMC;
    //private GatherInput gI;
    private Animator anim;

    public bool attackStarted = false;
    public PolygonCollider2D polyCol;
    public PolygonCollider2D polyCol2;
    public PolygonCollider2D polyCol3;
    public PolygonCollider2D polyCol4;
    public AudioSource source;

    public Bullet shotToFireBulletIce;
    public Bullet shotToFireBulletDragon;
    public Transform shotPoint;
    public bool canShot = true;


    private CoolDownSkill cooldownkill;

    

    // Start is called before the first frame update
    void Start()
    {

        cooldownkill = GameObject.FindGameObjectWithTag("CoolDown").GetComponent<CoolDownSkill>();
        pMC = GetComponent<PlayerMoveController>();
        //gI = GetComponent<GatherInput>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {

        if (/*gI.tryAttack||*/ CrossPlatformInputManager.GetButtonDown("Attack")|| Input.GetKeyDown(KeyCode.Q))//nếu nhấn
        {
            if (attackStarted || pMC.hasControl == false || pMC.knockBack ||pMC.onLadders)
                return;
            anim.SetBool("Attack", true);//Nếu cái if trên đúng thì return và lệnh này sẽ k chạy
            attackStarted = true;

            cooldownkill.UseSpell1();
        }

        if (/*gI.tryAttack||*/ CrossPlatformInputManager.GetButtonDown("Attack2")|| Input.GetKeyDown(KeyCode.E))//nếu nhấn
        {
            if (attackStarted || pMC.hasControl == false || pMC.knockBack || pMC.onLadders)
                return;
            anim.SetBool("Attack2", true);//Nếu cái if trên đúng thì return và lệnh này sẽ k chạy
            attackStarted = true;

            cooldownkill.UseSpell2();
        }

        if (/*gI.tryAttack||*/ CrossPlatformInputManager.GetButtonDown("Attack3") || Input.GetKeyDown(KeyCode.R))//nếu nhấn
        {
            if (attackStarted || pMC.hasControl == false || pMC.knockBack || pMC.onLadders)
                return;
            anim.SetBool("Attack3", true);//Nếu cái if trên đúng thì return và lệnh này sẽ k chạy
            attackStarted = true;

            cooldownkill.UseSpell3();

        }

        //if (CrossPlatformInputManager.GetButtonDown("BulletIce"))
        //{
        //    if (attackStarted || pMC.hasControl == false || pMC.knockBack || pMC.onLadders||canShot==false)
        //        return;
        //    Instantiate(shotToFireBulletIce, shotPoint.position, shotPoint.rotation);
        //    canShot = false;
        //    StartCoroutine(CanShot());
        //}
        if (CrossPlatformInputManager.GetButtonDown("BulletDragon")|| Input.GetKeyDown(KeyCode.T))
        {
            if (attackStarted || pMC.hasControl == false || pMC.knockBack || pMC.onLadders || canShot == false)
                return;
            anim.SetBool("Attack4", true);
            attackStarted = true;
            canShot = false;
            StartCoroutine(CanShot());

            cooldownkill.UseSpell4();
        }
    }




    public void AttackBullet()
    {
        Instantiate(shotToFireBulletDragon, shotPoint.position, shotPoint.rotation);
        
    }

    private IEnumerator CanShot()//thời gian k bị dính sát thương
    {
        yield return new WaitForSeconds(1f);//sau 0.15f mới di chuyển đc và dính sát thương
        canShot = true;
        
    }

    public void ActivateAttack()//dùng trong animation Attack
    {
        polyCol.enabled = true;
        source.Play();
    }

    public void ActivateAttack2()//dùng trong animation Attack
    {
        polyCol2.enabled = true;
        source.Play();
    }
    public void ActivateAttack3()//dùng trong animation Attack
    {
        polyCol3.enabled = true;
        source.Play();
    }
    public void ActivateAttack4()//dùng trong animation Attack
    {
        polyCol4.enabled = true;
        source.Play();
    }


    public void ResetAttack()//Hầm này sẽ đc gọi ở animation lúc kết thúc animation attack
    {
        anim.SetBool("Attack", false);
        //gI.tryAttack = false;//Giúp tránh việc ấn giữ nó vẫn đánh
        attackStarted = false;
        polyCol.enabled = false;
        source.Stop();
    }
    public void ResetAttack2()//Hầm này sẽ đc gọi ở animation lúc kết thúc animation attack
    {
        anim.SetBool("Attack2", false);
        //gI.tryAttack = false;//Giúp tránh việc ấn giữ nó vẫn đánh
        attackStarted = false;
        polyCol2.enabled = false;
        source.Stop();
    }
    public void ResetAttack3()//Hầm này sẽ đc gọi ở animation lúc kết thúc animation attack
    {
        anim.SetBool("Attack3", false);
        //gI.tryAttack = false;//Giúp tránh việc ấn giữ nó vẫn đánh
        attackStarted = false;
        polyCol3.enabled = false;
        source.Stop();
    }
    public void ResetAttack4()//Hầm này sẽ đc gọi ở animation lúc kết thúc animation attack
    {
        anim.SetBool("Attack4", false);
        //gI.tryAttack = false;//Giúp tránh việc ấn giữ nó vẫn đánh
        attackStarted = false;
        polyCol4.enabled = false;
        source.Stop();
    }

    
}
