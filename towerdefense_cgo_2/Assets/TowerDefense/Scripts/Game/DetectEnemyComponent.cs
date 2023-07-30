using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemyComponent : MonoBehaviour
{
    public AttackComponent attackComponent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            attackComponent.SetTarget(collision.transform);
        }    
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            attackComponent.SetTarget(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            attackComponent.SetTarget(null);
        }
    }

}
