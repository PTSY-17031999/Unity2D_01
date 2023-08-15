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
    public int location_tree_and_side;// Vị trí cây
    Rigidbody2D Connect_physical; // Kết nối tới vật lý 

    // Sét tham số cho Enemy
    public void Set_Value( int location_tree_and_side)
    {
        //Set loại Enemy trái or phải
        this.location_tree_and_side = location_tree_and_side;
        this._Speed = _Speed;
    }
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

    // Xử lý khi Enemy Die
    public void Handling_Enemy_Die()
    {
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        Connect_physical.AddForce(Vector2.up * 150);
        Connect_physical.AddForce(Vector2.right * 50);
        Debug.Log("Enemy Die");
    }
}
 