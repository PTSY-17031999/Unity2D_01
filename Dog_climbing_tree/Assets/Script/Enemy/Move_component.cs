
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Move_component : MonoBehaviour
{
    float speed = 1f; //Tốc độ
    public Path _path;
    private List<Vector3> _Path = new List<Vector3>();

    public Vector3 _startPos; // Vị trí bắt đầu của mỗi chặng
    public Vector3 _endPos;   // Vi trí kết thúc của mỗi chặng

    public int currentIndex = 0; // Biến đếm


    // Set tốc độ chạy và vị trí bất đầu 
    public void Set(float speed , int location_tree_and_side) 
    {
        this.speed = speed; // Sét tốc độ bằng tốc độ Enemy.
        _Path = _path.GetListPosition();
        transform.position = _Path[location_tree_and_side]; // sét đối tượng về vị trí bắt đàu di chuyển
        _startPos = _Path[location_tree_and_side]; // sét vị trí bắt đàu di chuyển mỗi chặng
        _endPos = _Path[location_tree_and_side + 1]; // sét vị trí kết thúc di chuyển mỗi chặng

       
    }

    private void Start()
    {
       
    }
    

    private void Update()
    {
        //if (Miss_Set == true) return;


            Movement();
        


    }

    private void Movement()
    {
        Vector3 direction = _endPos - _startPos; // Lấy hướng di chuyển
        direction.Normalize(); // Chuển nó thành - 1 hoặc 1
        transform.position += direction * speed * Time.deltaTime; // Cho đối tượng di chuyển

        if (Vector3.Distance(transform.position, _endPos) <= 0.05f) // Nếu vị trí hiện tại đến điểm cuối < = gần  đổi hướng
        {
            Destroy(gameObject);
        }
    }


 
}
