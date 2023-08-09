using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{//k dùng
    public float health;
    public string healthKey;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat(healthKey, health);//dùng để lưu số máu còn lại khi qua màn

        health = PlayerPrefs.GetFloat(healthKey, 100);

        if (PlayerPrefs.HasKey(healthKey))
        {

        }

        PlayerPrefs.DeleteKey(healthKey);
        PlayerPrefs.DeleteAll();
    }

    
}
