using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZoneCheck : MonoBehaviour
{
    private SelectonEnemy selectonParent;
    private bool inRange;
    private Animator anim;
    
    private void Awake()
    {
        selectonParent = GetComponentInParent<SelectonEnemy>();
        anim = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if(inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Selecton_Attack"))
        {
            selectonParent.Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            inRange = false;
            gameObject.SetActive(false);
            selectonParent.triggerArea.SetActive(true);
            selectonParent.inRange = false;
            selectonParent.SelectonTarget();
        }
    }
}
