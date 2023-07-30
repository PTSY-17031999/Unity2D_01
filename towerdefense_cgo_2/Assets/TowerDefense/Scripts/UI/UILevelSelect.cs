using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILevelSelect : MonoBehaviour
{
    public UILevelButton levelButtonPrefab;
    public int LevelCount = 2;
    public Transform levelButtonHolder;
    public Animator animator;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        for (int i = 0; i < LevelCount; i++)
        {
            UILevelButton levelBtn = Instantiate(levelButtonPrefab, levelButtonHolder);
            levelBtn.SetLevel(i + 1);
        }
    }

    public void CloseOnClicked()
    {
        animator.SetTrigger("close");
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
