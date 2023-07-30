using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public UIShopTowerDefense shopUI;
    public void ShowShop()
    {
        shopUI.gameObject.SetActive(true);
    }
    public void CloseShop()
    {
        shopUI.gameObject.SetActive(false);
    }
}