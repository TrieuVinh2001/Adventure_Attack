using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{//của Platform->PlatformParent
    public float speed;
    public Transform[] points;

    private int i;
    public int startingPoint;//đỉm bắt đầu

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoint].position;//vị trí bắt đầu
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)//Tính khoảng cách giữa 2 điểm(<0.02 nghĩa là gần như trùng nhau) thì sẽ tăng i (nghĩa là di chuyển đén điểm tiếp theo)
        {
            i++;
            if (i == points.Length)//nếu đi qua tất các điểm rồi thì về điểm đầu
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)//Khi chạm vào
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);//Player sẽ thành Object con của cái này và di chuyển theo nó
        }
    }

    private void OnCollisionExit2D(Collision2D collision)//Khi thoát ra khỏi 
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.transform.SetParent(null);//Player sẽ k còn là Object con của cái này vì đã thành null
        }
    }
}
