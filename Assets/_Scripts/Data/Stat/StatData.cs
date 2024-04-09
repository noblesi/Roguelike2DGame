using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Status", menuName = "ScriptableObject/StatusData")]
public class StatData : ScriptableObject
{
    public enum StatusType { HP, ATK, DEF, SPD, CriticalRate, CriticalDMG, Fortune}
    public enum StatusGrade { Normal, Rare, Unique}

    [Header("= Main Info =")]
    public StatusType statusType;
    public StatusGrade statusGrade;
    public int statusID;
    [TextArea] public string Description;

    public int iStatusIncreasement;
    public float fStatusIncresement;
    public float probability;
    public Sprite StatusIcon;
    public Material iconMaterial;
}
