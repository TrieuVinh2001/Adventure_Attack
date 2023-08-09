using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{//Script của PlayerStats->Player
    public float maxHealth;
    public float health;

    public bool canTakeDamage = true;
    public GameObject TextPoint;//Text sát thương

    private Animator anim;

    private PlayerMoveController playerMove;
    private PlayerAttackControl pAC;

    private Image healthUI;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        playerMove = GetComponentInParent<PlayerMoveController>();
        pAC = GetComponentInParent<PlayerAttackControl>();
        health = maxHealth;
        //health = PlayerPrefs.GetFloat("HealthKey", maxHealth);

        healthUI = GameObject.FindGameObjectWithTag("HealthUI").GetComponent<Image>();
        UpdateHealthUI();
    }

    public void TakeDamage(float damage)
    {
        if (canTakeDamage)
        {
            GameObject floatingText = Instantiate(TextPoint, transform.position, Quaternion.identity) as GameObject; //Clone text
            floatingText.transform.GetChild(0).GetComponent<TextMesh>().text = "" + damage;//Ghi chỉ số cho text
            health -= damage;
            anim.SetBool("Damage", true);
            playerMove.hasControl = false;//k thẻ di chuyển

            UpdateHealthUI();
            pAC.ResetAttack();
            pAC.ResetAttack2();
            pAC.ResetAttack3();
            pAC.ResetAttack4();

            if (health <= 0)
            {
                GetComponent<PolygonCollider2D>().enabled = false;
                //GetComponentInParent<GatherInput>().DisablControls();
                //Debug.Log("Dead");
                PlayerPrefs.SetFloat("HealthKey", maxHealth);//xét Key "HealthKey" lấy giá trị maxHealth
                PlayerPrefs.SetInt("GemNumber", 0);
                GameManager.ManagerRestartLevel();//restart lại level
            }
            StartCoroutine(HurtAnimation());
            StartCoroutine(DamagePrevention());
        }       
    }

    private IEnumerator DamagePrevention()//thời gian k bị dính sát thương
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(1f);//sau 0.15f mới tấn công được
        if (health > 0)
        {
            canTakeDamage = true;
            //playerMove.hasControl = true;
            //anim.SetBool("Damage", false);
        }
        else
        {
            anim.SetBool("Death", true);
        }
    }

    private IEnumerator HurtAnimation()
    {
        yield return new WaitForSeconds(0.3f);
        if (health > 0)
        {
            playerMove.hasControl = true;
            anim.SetBool("Damage", false);
        }
        else
        {
            anim.SetBool("Death", true);
        }
    }


    public void IncreaseHealth(float heal)//hồi máu
    {
        health += heal;

        if(health > maxHealth)
        {
            health = maxHealth;
        }

        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        healthUI.fillAmount = health / maxHealth;//Thanh máu giảm dần
    }

    //private void HCAttack1()
    //{

    //}

    private void OnApplicationQuit()//Khi thoát game thì xóa key đi tức là khi vào lại thì máu lại max
    {
        PlayerPrefs.DeleteKey("HealthKey");
    }
}
