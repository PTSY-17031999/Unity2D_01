using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float moving_speed;     // Vận tốc di chuyển
    Pipe_Controler _Pipe_Controler;
    Game_Controler _Game_Controler;

    // Start is called before the first frame update
    void Start()
    {
        _Pipe_Controler = FindObjectOfType<Pipe_Controler>();
        _Game_Controler = FindObjectOfType<Game_Controler>();


    }

    // Update is called once per frame
    void Update()
    {
        if (_Game_Controler.Get_Pause_Game()) return;
        transform.position -= new Vector3(moving_speed, 0, 0) * Time.deltaTime;

        if (transform.position.x < -3.26 || _Game_Controler.Get_Over_Game())
        {
            Destroy(gameObject);
        }
       


    }


    //SỰ KIỆN NHÂN VẬT CHẠM VỚI VẬT CẢN
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(" Location_plus_points"))
        {
            _Game_Controler.Plub_Score(1);

        }
    }
}
