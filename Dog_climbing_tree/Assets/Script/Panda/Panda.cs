using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panda : MonoBehaviour
{
    Game_Controller Conect_Class_Game_Controller;
    Audio_Controller Conect_Class_Audio_Controller;
    Rigidbody2D ThamChieuToiNhaVat;
    Move_Panda Conect_Move_Panda;
    public int location_tree_and_side; //Vị trí panda ở cây nào
    public float speed = 8f; // Tốc độ

    // Start is called before the first frame update
    void Start()
    {
        Conect_Class_Game_Controller = FindObjectOfType<Game_Controller>();
        Conect_Class_Audio_Controller = FindObjectOfType<Audio_Controller>();
        Conect_Move_Panda = FindObjectOfType<Move_Panda>();
        ThamChieuToiNhaVat = GetComponent<Rigidbody2D>();

        Conect_Move_Panda.Set_Star(5f, 6);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Handling_Panda_Die()
    {
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        ThamChieuToiNhaVat.AddForce(Vector2.up * 150);
        ThamChieuToiNhaVat.AddForce(Vector2.right * 50);
        Conect_Class_Game_Controller.Set_Over_Game(true);
        Debug.Log("Panda touches the ground, game over");
        Conect_Class_Audio_Controller.Play_Panda_Dead_sound();
    }


    //SỰ KIỆN NHÂN VẬT CHẠM ĐẤT
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Panel_AD_or_Ground"))
        {
            Handling_Panda_Die();
        }
    }
}
