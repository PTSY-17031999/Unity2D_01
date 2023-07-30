using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Projectile : MonoBehaviour
{ //Di chuyển mũi tên


    public float Speed; // Tốc độ di chuyển
    public float Time_Destroy; //Thời gian tồn tại
    private float Time_Destroy_Curent = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time_Destroy -= Time.deltaTime;
        if ( Time_Destroy <=0)
        {
            Destroy(gameObject);
            return;
        }

        //Mũi tên sẽ bay theo hướng của trục tọa độ mầu đỏ của mũi tên, xoay hướng mũi tên hướng nào thi mũi tên bay hứng đó
        transform.position += transform.right * Speed * Time.deltaTime;

    }
}
