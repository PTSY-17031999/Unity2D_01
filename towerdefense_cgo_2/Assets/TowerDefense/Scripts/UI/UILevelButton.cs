using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UILevelButton : MonoBehaviour
{
    public int Level;
    public TextMeshProUGUI txtLevel;

    public void SetLevel(int level)
    {
        this.Level = level;
        txtLevel.text = this.Level.ToString();
    }

    public void LevelButtonOnClicked()
    {
        Debug.Log("Chuyen sang level " + Level);
        SceneManager.LoadScene("Map " + this.Level);
    }
}
