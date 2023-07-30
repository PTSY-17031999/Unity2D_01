using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITowerItem : MonoBehaviour
{
    private TowerItemSO towerSO;
    public Image towerIcon;
    public TextMeshProUGUI costText;

    public void SetItem(TowerItemSO data)
    {
        this.towerSO = data;
        towerIcon.sprite = data.iconTower;
        towerIcon.SetNativeSize();

        costText.text = data.Cost.ToString();
    }

    public void BuyTowerOnClicked()
    {
        if (DataManager.Instance.GetCost() >= towerSO.Cost)
        {
            UIManager.Instance.CloseShop();

            // Co the mua duoc
            DataManager.Instance.SubstractCost(towerSO.Cost);

            Tower tower = Instantiate(towerSO.prefab);
            tower.transform.position = UIManager.Instance.shopUI.GetTileTower().transform.position;

            UIManager.Instance.shopUI.GetTileTower().DestroyTileTower();
        }
        else
        {
            Debug.Log("Cannot buy");
        }
    }
}