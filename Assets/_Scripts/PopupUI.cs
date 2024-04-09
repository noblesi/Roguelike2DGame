using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupUI : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Open(System.Action onOpened = null)
    {
        gameObject.SetActive(true);
    }
}
