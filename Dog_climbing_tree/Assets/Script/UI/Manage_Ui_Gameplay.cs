using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manage_Ui_Gameplay : MonoBehaviour
{

    // Panel Game Play
    public GameObject Panel_Play;
    #region Score
    public List<GameObject> Score_Unit;
    public List<GameObject> Score_Dozen;
    public List<GameObject> Score_Hundred;
    #endregion
    #region Time_Live
    public List<GameObject> Time_Unit;
    public List<GameObject> Time_Dozen;
    public List<GameObject> Time_Hundred;
    public List<GameObject> Time_Thousand;

    #endregion

    // Panel Game over
    public GameObject Panel_Game_over;
    #region Score_Over
    public List<GameObject> Score_Over_Unit;
    public List<GameObject> Score_Over_Dozen;
    public List<GameObject> Score_Over_Hundred;
    #endregion

    
    public void Start()
    {
        // Ẩn toàn bộ các các số thời gian và điểm
        for (int i = 0; i <= Score_Unit.Count - 1; i++)
        {
            // Ẩn toàn bộ điểm khi khởi chạy
            Score_Unit[i].SetActive(false);
            Score_Dozen[i].SetActive(false);
            Score_Hundred[i].SetActive(false);

            // Ẩn toàn bộ thời gian khi khởi chạy
            Time_Unit[i].SetActive(false);
            Time_Dozen[i].SetActive(false);
            Time_Hundred[i].SetActive(false);
            Time_Thousand[i].SetActive(false);

            // Ẩn toàn bộ điểm hiện trên panel over game khi khởi chạy
            Score_Over_Unit[i].SetActive(false);
            Score_Over_Dozen[i].SetActive(false);
            Score_Over_Hundred[i].SetActive(false);

        }
        processing(0, Score_Unit, Score_Dozen, Score_Hundred, null);
    }

    float Miss_Time = 0;
    float _Time = 1f;
    
    private void Update()
    {
       
        // Xử lý thời gian sống
        Miss_Time += Time.deltaTime;
        if (Miss_Time >= _Time)
        {
            //Debug.Log((int)Math.Round(Time.time));
            processing((int)Math.Round(Time.time), Time_Unit, Time_Dozen, Time_Hundred, Time_Thousand);
            Miss_Time = 0;
        }
    }


    // Xử lý show panel play hoặc panel game over
    public void Show_Panel_Play_or_Over()
    {
        if(Panel_Play.activeInHierarchy != true)
        {
            Panel_Play.SetActive(true);
            Panel_Game_over.SetActive(false);
        }
        else StartCoroutine(WaitForMoving());
    }
    private IEnumerator WaitForMoving()
    {
        yield return new WaitForSeconds(2); // Chờ 2s mới dược chạy hàm Start_Move
        Panel_Play.SetActive(false);
        Panel_Game_over.SetActive(true);
    }


    // Xử lý điểm chơi
    public void Change_Score(int Score)
    {
        processing(Score, Score_Unit, Score_Dozen, Score_Hundred, null);

    }


    // Xử lý điểm hiện trên panel Over game
    public void Change_Score_Over(int Score)
    {
        processing(Score, Score_Over_Unit, Score_Over_Dozen, Score_Over_Hundred, null);

    }


    // Xử lý chuyển số sang hình ảnh
    void processing(int number, List<GameObject> Unit, List<GameObject> Dozen, List<GameObject> Hundred, List<GameObject> Thousand)
    {
        
        for (int i = 0; i <= Unit.Count - 1; i++)
        {
            if (Unit != null) Unit[i].SetActive(false);
            if (Dozen != null) Dozen[i].SetActive(false);
            if (Hundred != null) Hundred[i].SetActive(false);
            if (Thousand != null) Thousand[i].SetActive(false);
        }


        if (number > 9999) return;
        string a = number.ToString();
        if (a.Length == 1 & Unit != null) Unit[int.Parse(a[0].ToString())].SetActive(true);
        if (a.Length == 2 & Unit != null & Dozen != null)
        {
            Unit[int.Parse(a[1].ToString())].SetActive(true);
            Dozen[int.Parse(a[0].ToString())].SetActive(true);
            }
        if (a.Length == 3 & Unit != null & Dozen != null & Dozen != null)
        {
            Unit[int.Parse(a[2].ToString())].SetActive(true);
            Dozen[int.Parse(a[1].ToString())].SetActive(true);
            Hundred[int.Parse(a[0].ToString())].SetActive(true);
        }
        if (a.Length == 4 & Unit != null & Dozen != null & Dozen != null & Thousand != null)
        {
            Dozen[int.Parse(a[3].ToString())].SetActive(true);
            Unit[int.Parse(a[2].ToString())].SetActive(true);
            Hundred[int.Parse(a[1].ToString())].SetActive(true);
            Thousand[int.Parse(a[0].ToString())].SetActive(true);
        }
        


    }
}
