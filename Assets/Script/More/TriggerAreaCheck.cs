using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaCheck : MonoBehaviour
{
    private SelectonEnemy selectonParent;

    private void Awake()
    {
        selectonParent = GetComponentInParent<SelectonEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            selectonParent.target = collider.transform;
            selectonParent.inRange = true;
            selectonParent.hotZone.SetActive(true);
        }
    }
}
