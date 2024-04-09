using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    public StatData data;
    public Player player;

    Image icon;
    Text textGrade;
    Text textType;
    Text textDesc;

    private void Awake()
    {
        icon = GetComponentsInChildren<Image>()[1];
        icon.sprite = data.StatusIcon;
        icon.material = data.iconMaterial;

        Text[] texts = GetComponentsInChildren<Text>();
        textGrade = texts[0];
        textType = texts[1];
        textDesc = texts[2];
        textGrade.text = data.statusGrade.ToString();
        textType.text = data.statusType.ToString();
        textDesc.text = data.Description;
    }

    

    public void OnClick()
    {
        switch (data.statusType)
        {
            case StatData.StatusType.HP:
                player.maxHp += data.iStatusIncreasement;
                break;
            case StatData.StatusType.ATK:
                player.Atk += data.iStatusIncreasement;
                break;
            case StatData.StatusType.DEF:
                player.Def += data.iStatusIncreasement;
                break;
            case StatData.StatusType.SPD:
                player.Spd += data.iStatusIncreasement;
                break;
            case StatData.StatusType.CriticalRate:
                player.critRate += data.fStatusIncresement;
                break;
            case StatData.StatusType.CriticalDMG:
                player.critDmg += data.fStatusIncresement;
                break;
            case StatData.StatusType.Fortune:
                player.fortune += data.fStatusIncresement;
                break;
        }
    }
}
