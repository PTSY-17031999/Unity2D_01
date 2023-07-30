using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float moving_speed;     // Vận tốc di chuyển
    Rigidbody2D ThamChieuToiNhaVat;
    public float LucNhay;
    public AudioSource tham_chieu_den_cac_file_am_thanh;
    public AudioClip At_bay;
    public AudioClip At_chet;
    Game_Controler _Game_Controler;
    // Start is called before the first frame update
    void Start()
    {
        _Game_Controler = FindObjectOfType<Game_Controler>();
        ThamChieuToiNhaVat = GetComponent<Rigidbody2D>();
        LucNhay = 250;
            moving_speed = (moving_speed / 10000);
        
    }

    // Update is called once per frame
    void Update()
    {
        //Xoay hướng con chim xuống 
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -20f), Time.deltaTime * 0.5f);
        if (_Game_Controler.Get_Pause_Game()) Destroy(gameObject);
        if (_Game_Controler.Get_Over_Game()) return;
        bool Phim_khoang_cach_duoc_nhan = Input.GetKeyDown(KeyCode.Space);
        if (Phim_khoang_cach_duoc_nhan && At_bay)
        {
            ThamChieuToiNhaVat.AddForce(Vector2.up * LucNhay);
            tham_chieu_den_cac_file_am_thanh.PlayOneShot(At_bay);

            //Xoay hướng con chim lên 
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 20f), Time.deltaTime * 1.5f);

            //ThamChieuToiNhaVat.AddForce(new Vector2(0, LucNhay) , ForceMode2D.Force);
        }

        /* * KIỂM TRA XEM NGƯỜI CHƠI CÓ NHẤN PHÍM KHOẢNG CÁCH KO VÀ NHÂN VẬT CÓ
		   * CHẠM ĐẤT KHÔNG NÊU CẢ HAI TRẢ VỀ TRUE THÌ CHO PHÉP NHÂN VẬT NHẢY LÊN */
  
           
            
        
    }



    // SỰ KIỆN NHÂN VẬT CHẠM ĐẤT Và ống
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Pipe") || col.gameObject.CompareTag("Ground"))
        {
            if (_Game_Controler.Get_Over_Game() == false)
            {
                _Game_Controler.Set_Over_Game(true);
            }
        }
    }

    // Trả về vị trí con chim, tạo lại con chim sau khi pause
    public float Get_vi_tri_Bird()
    {
        return transform.position.y;
    }

}
