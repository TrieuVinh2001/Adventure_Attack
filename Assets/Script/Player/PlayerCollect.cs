using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollect : MonoBehaviour
{//của Player
    //public Text textComponent;
    private Text textComponent;
    public int gemNumber;
    // Start is called before the first frame update
    void Start()
    {

        //gemNumber = PlayerPrefs.GetInt("GemNumber", 0);//bắt đầu cần tạo giá trị cho nó
        gemNumber = 0;
        //Tìm cái có Tag là GemUI và Text kèm theo nó (giúp thuận tiện làm level khác k cần kéo Text của nó vào Public Text textComonent nữa(Nhớ là gem ở UI chứ k phải Gem)
        textComponent = GameObject.FindGameObjectWithTag("GemUI").GetComponentInChildren<Text>();

        UpdateText();
    }

    // Update is called once per frame
    void UpdateText()
    {
        textComponent.text = gemNumber.ToString();
    }

    public void GemCollected()
    {
        gemNumber += 1;
        UpdateText();
    }
}
