using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Controler : MonoBehaviour
{
   public Pipe _Pipe;
   public float Time_inset;
   float Count_time;
   Game_Controler _Game_Controle;
    private void Start()
    {
        Count_time = 0;
        _Game_Controle = FindObjectOfType<Game_Controler>();
    }
    private void Update()
    {
        if (_Game_Controle.Get_Pause_Game()) return;
        if (_Game_Controle.Get_Over_Game()) return;
        Count_time += Time.deltaTime;
        if (Time_inset > Count_time) { return; }
        Inset_pipe();
    }
    public void Inset_pipe()
    {
        Count_time = 0;
        float Ngau_nhien_Y = Random.Range(-3.45f, 0.9f);
        Vector2 Vi_tri_se_tao = new Vector2(3.2f, Ngau_nhien_Y);
        if (_Pipe)// NẾU VẬT CẢN CHƯA GÁN VÀO THÌ KHÔNG CHẠY
        {
            Instantiate(_Pipe, Vi_tri_se_tao, Quaternion.identity);
        }
    }
}
