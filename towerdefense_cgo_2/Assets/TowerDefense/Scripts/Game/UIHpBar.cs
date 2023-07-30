using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHpBar : MonoBehaviour
{
    public Image hpMain;

    public void UpdateHp(float percent)
    {
        hpMain.fillAmount = percent;
    }
}
