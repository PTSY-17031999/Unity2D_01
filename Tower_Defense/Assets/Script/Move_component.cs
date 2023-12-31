﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Move_component : MonoBehaviour
{
    public float speed = 8f; // Tốc độ
    public Path _path;
    private List<Vector3> _Path = new List<Vector3>();

    public Vector3 _startPos; // Vị trí bắt đầu của mỗi chặng
    public Vector3 _endPos;   // Vi trí kết thúc của mỗi chặng

    public int currentIndex = 0; // Biến đếm
    private bool isReached = false; // kiểm tra đã tới đích chưa



    // Set tốc độ chạy
    public void Set(float speed)
    {
        Debug.Log("NG");
        this.speed = speed; // Sét tốc độ bằng tốc độ Enemy.
        _Path = _path.GetListPosition();
        transform.position = _Path[0]; // sét đối tượng về vị trí bắt đàu di chuyển
        _startPos = _Path[currentIndex]; // sét vị trí bắt đàu di chuyển mỗi chặng
        _endPos = _Path[currentIndex + 1]; // sét vị trí kết thúc di chuyển mỗi chặng
                                           // _Path  
    }

    private void Start()
    {
       
    }
    

    private void Update()
    {
        if (isReached == false)
        {
            Movement();
        }


    }

    private void Movement()
    {
        Vector3 direction = _endPos - _startPos; // Lấy hướng di chuyển
        direction.Normalize(); // Chuển nó thành - 1 hoặc 1
        transform.position += direction * speed * Time.deltaTime; // Cho đối tượng di chuyển

        if (Vector3.Distance(transform.position, _endPos) <= 0.05f) // Nếu vị trí hiện tại đến điểm cuối < = gần  đổi hướng
        {
            currentIndex += 1;
            if (currentIndex == _Path.Count - 1)
            {
                //ket thuc
                isReached = true;
                return;
            }

            _startPos = _Path[currentIndex];
            _endPos = _Path[currentIndex + 1];
        }
    }


    //public void Set(float speed)
   // {
        //     this.speed = speed;
        //     path = AllPath[UnityEngine.Random.Range(0, AllPath.Count)];
        //     Path = new List<Vector3>();
        //     Path = path.GetListPosition();
        //     transform.position = Path[0];
        //    startPos = Path[currentIndex];
        // endPos = Path[currentIndex + 1];
  //  }
}
