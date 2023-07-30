using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UIShop : MonoBehaviour
{
    [SerializeField] private ShopItem shopItemPrefab;
    [SerializeField] private List<ShopItemSO> database;
    [SerializeField] private Transform parentShopItem;

    private List<ShopItem> listShopItem = new List<ShopItem>();
    private bool isInit = false;

    private void Awake()
    {
        // Resources/Database => Database/1
        shopItemPrefab = Resources.Load<ShopItem>("UI/UIShopItem");
        database = Resources.LoadAll<ShopItemSO>("Database").ToList();
    }

    private void InitShop()
    {
        for(int i = 0; i < 9; i++)
        {
            var shopItem = Instantiate(shopItemPrefab, parentShopItem);
            listShopItem.Add(shopItem);
        }
    }

    private void OnEnable()
    {
        database.Sort();
        if (!isInit)
        {
            InitShop();
            isInit = true;
        }
        RandomItem();
    }

    private void RandomItem()
    {
        List<ShopItemSO> listShopData = new List<ShopItemSO>();
        List<ShopItemSO> tempShopData = new List<ShopItemSO>(database);
        // 1 2 3 4 5 6 7 
        // rado, =4
        //=> 1 2 5 6 7
        //
        for (int i = 0; i < 9; i++)
        {
            int random = Random.Range(0, tempShopData.Count);
            listShopData.Add(database[random]);
            tempShopData.RemoveAt(random);
        }

        for (int i = 0; i < 9; i++)
        {
            listShopItem[i].SetInfo(listShopData[i]);
        }

    }
}
