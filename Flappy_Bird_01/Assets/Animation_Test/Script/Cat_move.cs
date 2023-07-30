using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_move : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
    public bool Moving;
    public Animator Ani;
    public float movement;
    void Start()
    {
        Ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       //Nhận tín hiệu từ bàn phím
        movement = Input.GetAxis("Horizontal");

        //Quay đầu con mèo lại
        if(movement == 0) { }
        else if (movement < 0)
        {
            transform.Rotate(0f, - 180f, 0.0f, Space.Self);
        }
        else if(movement > 0)
        {
            transform.Rotate(0f, 0.0f, 0.0f, Space.Self);
        }

        // Di chuyển con mèo
        transform.position += new Vector3(movement * Speed * Time.deltaTime, 0, 0);

      

            if (movement == 0) { Moving = false; }
        else { Moving = true; }

        Ani.SetBool("Move", Moving);
    }
}
