using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    public void ShowLevelUpUI()
    {
        rect.localScale = Vector3.one;
        GameManager.Instance.Stop();
    }

    public void HideLevelUpUI()
    {
        rect.localScale = Vector3.zero;
        GameManager.Instance.Resume();
    }

    void Next()
    {

    }
}
