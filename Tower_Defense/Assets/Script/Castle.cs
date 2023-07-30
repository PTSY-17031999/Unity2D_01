using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    float Hp; // Mấu

    public void Damage(float _Damage)
    {
        Hp -= _Damage;
    }
}
