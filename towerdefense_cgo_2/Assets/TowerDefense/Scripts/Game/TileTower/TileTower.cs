using UnityEngine;

public class TileTower : MonoBehaviour
{
    // truyen ham nay vao button de no chay ham
    public void TileTowerOnClicked()
    {
        Debug.Log("Dang bam vao tile tower: " + gameObject.name);

        UIManager.Instance.ShowShop();
        UIManager.Instance.shopUI.SetTileTower(this);
    }

    public void DestroyTileTower()
    {
        Destroy(gameObject);
    }
}