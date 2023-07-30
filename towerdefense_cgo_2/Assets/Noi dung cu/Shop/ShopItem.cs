using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private Image iconImg;
    [SerializeField] private TextMeshProUGUI costTxt;
    private ShopItemSO data;
    public void SetInfo(ShopItemSO itemData)
    {
        this.data = itemData;
        iconImg.sprite = itemData.iconItem;
        costTxt.text = itemData.cost.ToString();
        //
    }

    public void BuyItemOnClicked()
    {
        int costPlayer = GameManager.Instance.Cost;
        if (costPlayer >= data.cost)
        {
            Debug.Log("Mua thanh cong!!");
            GameManager.Instance.Cost -= data.cost;
        }
        else
        {
            Debug.Log("Mua that bai vi khong du tien!!");
        }
    }
}
