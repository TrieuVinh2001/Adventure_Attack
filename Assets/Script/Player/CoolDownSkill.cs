using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CoolDownSkill : MonoBehaviour
{
    //public static CoolDownSkill instance;
    public GameObject image1;
    private Image imageCoolDown1;
    public TMP_Text textCoolDown1;

    public GameObject image2;
    private Image imageCoolDown2;
    public TMP_Text textCoolDown2;

    public GameObject image3;
    private Image imageCoolDown3;
    public TMP_Text textCoolDown3;

    public GameObject image4;
    private Image imageCoolDown4;
    public TMP_Text textCoolDown4;

    private bool isCoolDown1 = false;
    private bool isCoolDown2 = false;
    private bool isCoolDown3 = false;
    private bool isCoolDown4 = false;

    public float timeSkill_1 = 10.0f;
    public float timeSkill_2 = 10.0f;
    public float timeSkill_3 = 10.0f;
    public float timeSkill_4 = 10.0f;

    private float coolDownTimer1 = 0f;
    private float coolDownTimer2 = 0f;
    private float coolDownTimer3 = 0f;
    private float coolDownTimer4 = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //textCoolDown.gameObject.SetActive(false);
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(false);
        image4.gameObject.SetActive(false);

        imageCoolDown1 = image1.GetComponent<Image>();
        imageCoolDown2 = image2.GetComponent<Image>();
        imageCoolDown3 = image3.GetComponent<Image>();
        imageCoolDown4 = image4.GetComponent<Image>();

        imageCoolDown1.fillAmount = 0.0f;
        imageCoolDown2.fillAmount = 0.0f;
        imageCoolDown3.fillAmount = 0.0f;
        imageCoolDown4.fillAmount = 0.0f;
        //imageCoolDown.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isCoolDown1)
        {
            ApplyCoolDown1();
        }
        if (isCoolDown2)
        {
            ApplyCoolDown2();
        }
        if (isCoolDown3)
        {
            ApplyCoolDown3();
        }
        if (isCoolDown4)
        {
            ApplyCoolDown4();
        }
    }

    private void ApplyCoolDown1()
    {
        coolDownTimer1 -= Time.deltaTime;
        if(coolDownTimer1 < 0.0f)
        {
            image1.gameObject.SetActive(false);
            isCoolDown1 = false;
            textCoolDown1.gameObject.SetActive(false);
            imageCoolDown1.fillAmount = 0.0f;
        }
        else
        {
            imageCoolDown1.enabled = true;
            //textCoolDown1.text = "" + coolDownTimer1;
            textCoolDown1.text = Mathf.RoundToInt(coolDownTimer1).ToString();//ép kiểu số nguyên
            imageCoolDown1.fillAmount = coolDownTimer1 / timeSkill_1;
        }
    }

    private void ApplyCoolDown2()
    {
        coolDownTimer2 -= Time.deltaTime;
        if (coolDownTimer2 < 0.0f)
        {
            image2.gameObject.SetActive(false);
            isCoolDown2 = false;
            textCoolDown2.gameObject.SetActive(false);
            imageCoolDown2.fillAmount = 0.0f;
        }
        else
        {
            imageCoolDown2.enabled = true;
            //textCoolDown2.text = "" + coolDownTimer2;
            textCoolDown2.text = Mathf.RoundToInt(coolDownTimer2).ToString();//ép kiểu số nguyên
            imageCoolDown2.fillAmount = coolDownTimer2 / timeSkill_2;
        }
    }

    private void ApplyCoolDown3()
    {
        coolDownTimer3 -= Time.deltaTime;
        if (coolDownTimer3 < 0.0f)
        {
            image3.gameObject.SetActive(false);
            isCoolDown3 = false;
            textCoolDown3.gameObject.SetActive(false);
            imageCoolDown3.fillAmount = 0.0f;
        }
        else
        {
            
            imageCoolDown3.enabled = true;
            //textCoolDown3.text = "" + coolDownTimer3;
            textCoolDown3.text = Mathf.RoundToInt(coolDownTimer3).ToString();//ép kiểu số nguyên
            imageCoolDown3.fillAmount = coolDownTimer3 / timeSkill_3;
        }
    }

    private void ApplyCoolDown4()
    {
        coolDownTimer4 -= Time.deltaTime;
        if (coolDownTimer4 < 0.0f)
        {
            image4.gameObject.SetActive(false);
            isCoolDown4 = false;
            textCoolDown4.gameObject.SetActive(false);
            imageCoolDown4.fillAmount = 0.0f;
        }
        else
        {
            imageCoolDown4.enabled = true;
            //textCoolDown4.text = "" + coolDownTimer4;
            textCoolDown4.text = Mathf.RoundToInt(coolDownTimer4).ToString();//ép kiểu số nguyên
            imageCoolDown4.fillAmount = coolDownTimer4 / timeSkill_4;
        }
    }

    public void UseSpell1()
    {
        if (!isCoolDown1)
        {
            image1.gameObject.SetActive(true);
            imageCoolDown1.enabled = true;
            isCoolDown1 = true;
            textCoolDown1.gameObject.SetActive(true);          
            coolDownTimer1 = timeSkill_1;
        }
    }

    public void UseSpell2()
    {
        if (!isCoolDown2)
        {
            image2.gameObject.SetActive(true);
            imageCoolDown2.enabled = true;
            isCoolDown2 = true;
            textCoolDown2.gameObject.SetActive(true);
            coolDownTimer2 = timeSkill_2;
        }
    }

    public void UseSpell3()
    {
        if (!isCoolDown3)
        {
            image3.gameObject.SetActive(true);
            imageCoolDown3.enabled = true;
            isCoolDown3 = true;
            textCoolDown3.gameObject.SetActive(true);
            coolDownTimer3 = timeSkill_3;
        }
    }

    public void UseSpell4()
    {
        if (!isCoolDown4)
        {
            image4.gameObject.SetActive(true);
            imageCoolDown4.enabled = true;
            isCoolDown4 = true;
            textCoolDown4.gameObject.SetActive(true);
            coolDownTimer4 = timeSkill_4;
        }
    }

}
