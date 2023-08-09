using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameObject gemParticle;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.RegisterGem(this);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))//nếu gameObject này(gem) chạm vào player có Tag là Player
        {

            collision.GetComponent<PlayerCollect>().GemCollected();

            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().enabled = false;//ẩn hình ảnh
            GetComponent<CircleCollider2D>().enabled = false;//ẩn viền CircleCollider

            Instantiate(gemParticle, transform.position, transform.rotation);
            GameManager.RemoveGemFromList(this);
            //Destroy(gameObject);//xóa gameObject
        }
    }
}
