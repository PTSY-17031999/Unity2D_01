using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public int Cost = 200;
    private void Awake()
    {
        Instance = this;
    }

    public int GetCost()
    {
        return Cost;
    }
    public void AddCost(int value)
    {
        Cost += value;
    }
    public void SubstractCost(int value)
    {
        Cost -= value;
    }
}