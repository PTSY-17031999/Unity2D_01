using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manage_Ui_Gameplay : MonoBehaviour
{
    #region Time_Life
    public List< GameObject> Time_Unit;
    public List<GameObject> Time_Dozen;
    public List<GameObject> Time_Hundred;
    public List<GameObject> Time_Thousand;
    #endregion

    #region Score
    public List<GameObject> Score_Unit;
    public List<GameObject> Score_Dozen;
    public List<GameObject> Score_Hundred;
    #endregion

    private void Start()
    {
        // Ẩn toàn bộ các các số thời gian và điểm
        for (int i = 0; i<= Time_Unit.Count - 1 ; i++) {
            Debug.Log(i);
            Time_Unit[i].SetActive(false);
            Time_Dozen[i].SetActive(false);
            Time_Hundred[i].SetActive(false);
            Time_Thousand[i].SetActive(false);
            Score_Unit[i].SetActive(false);
            Score_Dozen[i].SetActive(false);
            Score_Hundred[i].SetActive(false);
        }
    }
    private void Update()
    {
        Change_Score(10);
    }

    public void Change_Score(int Score)
    {
        //  name.SetActive(false);

    }
}
