using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float _Speed = 1f; // Tốc độ di chuyển
    float _Def;
    float _AttackDmg;
    int _IdWave;
    public Move_component _Move_Component; // Kết nối tới file class Move_component
    public int location_tree_and_side = 1;

    private void Start()
    {
        StartCoroutine(WaitForMoving());
    }

    private IEnumerator WaitForMoving()
    {
        yield return new WaitForSeconds(2); // Chờ 2s mới dược chạy hàm Start_Move
        Start_Move();
    }
    private void Start_Move()
    {
        _Move_Component.Set(_Speed, location_tree_and_side);
    }
}
 