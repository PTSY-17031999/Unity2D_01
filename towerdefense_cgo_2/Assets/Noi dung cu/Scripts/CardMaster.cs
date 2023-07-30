using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardMaster : MonoBehaviour
{
    [SerializeField] protected Image artWorkImg;
    [SerializeField] protected TextMeshProUGUI manaText;
    [SerializeField] protected TextMeshProUGUI dmgTxt;
    [SerializeField] protected TextMeshProUGUI hpTxt;

    [SerializeField] private CardSO cardSO;


    public void SetInfor(CardSO card)
    {
        this.cardSO = card;

        artWorkImg.sprite = cardSO.artWork;
        artWorkImg.SetNativeSize();

        manaText.text = cardSO.mana.ToString();
        dmgTxt.text = cardSO.dmg.ToString();
        hpTxt.text = cardSO.hp.ToString();
    }
}
