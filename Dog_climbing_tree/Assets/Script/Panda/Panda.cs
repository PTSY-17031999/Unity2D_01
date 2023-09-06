using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panda : MonoBehaviour
{
    Game_Controller Conect_Class_Game_Controller;
    Audio_Controller Conect_Class_Audio_Controller;
    Rigidbody2D Connect_physical; //Kết nối tới vật lý của nhân vật
    Move_Panda Conect_Move_Panda;
    public int location_tree_and_side; //Vị trí panda ở cây nào
    public float speed = 8f; // Tốc độ
    Enemy Conect_Class_Enemy;
    BoxCollider2D _BoxCollider2D;

    // Ket nối để thấy đổi Panda
    public GameObject Panda_Right;
    public GameObject Panda_Left;

    Panda_Animation_Controller Conect_P_A_C;

    // Start is called before the first frame update
    void Start()
    {
        Conect_Class_Game_Controller = FindObjectOfType<Game_Controller>();
        Conect_Class_Audio_Controller = FindObjectOfType<Audio_Controller>();
        Conect_Move_Panda = FindObjectOfType<Move_Panda>();
        Connect_physical = GetComponent<Rigidbody2D>();
        Conect_Class_Enemy = FindObjectOfType<Enemy>();
        _BoxCollider2D = FindObjectOfType<BoxCollider2D>();
        Conect_P_A_C = FindObjectOfType<Panda_Animation_Controller>();

        Conect_Move_Panda.Set_Star(5f);

    }

    // Update is called once per frame
    void Update()
    {

    }


    // Xử lý khi Panda DIE
    void Handling_Panda_Die()
    {

        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        Connect_physical.AddForce(Vector2.up * 150);
        Conect_Class_Game_Controller.Set_Over_Game(true);
        _BoxCollider2D.enabled = false;
        Debug.Log("Panda touches the ground, game over");
        Conect_Class_Audio_Controller.Play_Panda_Dead_sound();
    }




    //Panda chạm đất or chạm Enemy
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (Conect_Class_Game_Controller.Get_Over_Game() != false) return;
        //SỰ KIỆN NHÂN VẬT CHẠM ĐẤT
        if (col.CompareTag("Panel_AD_or_Ground"))
        {
            Handling_Panda_Die();
        }
        //Sự kiện Panda chạm Enemy
        if (col.CompareTag("Enemy"))
        {
            // Tiêu diệt Enemy khi Panda đang ở chế độ tấn công
            if (Conect_Move_Panda.Return_Panda_Attack() == true)
            {
                col.GetComponent<Enemy>().Handling_Enemy_Die();
                return;
            }
            // Panda chết khi chạm vào Enemy khi chức năng tấn công ko được bật
            Handling_Panda_Die();
        }

    }


    //Lựa chọn animation và panda left hoặc right
    public void Choose_Panda(int Last_Location, int location_tree_and_side)
    {
        
        this.location_tree_and_side = location_tree_and_side;
        #region Anmation di chuyển qua lại trên 1 cây
        //if (Last_Location == 0 && location_tree_and_side == 2 || Last_Location == 4 && location_tree_and_side == 6 || Last_Location == 8 && location_tree_and_side == 10)

        if (location_tree_and_side % 4 != 0)
        {
            Panda_Right.SetActive(true);
            Panda_Left.SetActive(false);
            Conect_P_A_C.Set_Status(6);
        }
        else
        {
            Panda_Right.SetActive(false);
            Panda_Left.SetActive(true);
            Conect_P_A_C.Set_Status(6);
        }
        #endregion


        //Cây này sang cây kia 2-4, 6-8, 8-6, 4-2
        //Trái phải trên 1 cây 0-2, 4-6, 8-10, 10-8, 6-4, 2-0

    }

    public void Choose_Panda(bool Panda_Move_Up , bool Panda_Move_Down)
    {

        #region Animation di chuyển lên
        if (Panda_Move_Up == true)
        {
            Conect_P_A_C.Set_Status(0);
            return;
        }
        #endregion

        #region Animation di chuyển xuống
        if (Panda_Move_Down == true)
        {
            Conect_P_A_C.Set_Status(1);
            Debug.Log("Down1111");
            return;
        }
        #endregion

        #region Đứng yên
        Conect_P_A_C.Set_Status(5);
        #endregion
    }
}
