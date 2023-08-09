using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    //public int lvlToLoad;//Số thứ tự scene
    public string lvlToLoad;//Tên scene
    public Sprite unlockedSprite;
    private BoxCollider2D boxCol;

    void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
        GameManager.RegisterDoor(this);//kết nối với GameManager
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //GetComponent<BoxCollider2D>().enabled = false;
            boxCol.enabled = false;
            //collision.GetComponent<GatherInput>().DisablControls();//k ther di chuyển

            PlayerStats playerStats = collision.GetComponentInChildren<PlayerStats>();
            PlayerPrefs.SetFloat("HealthKey", playerStats.health);//xét lấy số máu lúc chạm cửa

            PlayerCollect collect = collision.GetComponent<PlayerCollect>();
            PlayerPrefs.SetInt("GemNumber", collect.gemNumber);

            GameManager.ManagerLoadLevel(lvlToLoad);
            
        }
    }

    public void UnlockDoor()
    {
        GetComponent<SpriteRenderer>().sprite = unlockedSprite;//Thay đổi hình ảnh cửa
        boxCol.enabled = true;//hiện lại boxCollider
    }
}
