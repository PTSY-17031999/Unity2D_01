using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemyComponent : MonoBehaviour
{
    public Attack_component Attack_Component; // kết nối tới class Attack_Component

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Attack_Component.SetTarget(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
           // Attack_Component.SetTarget(null);
        }
    }
}
