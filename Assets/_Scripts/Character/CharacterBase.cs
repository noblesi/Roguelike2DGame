using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
    Player,
    Normal,
    Elite,
    Boss
}
public class CharacterBase
{
    public UnitType unitType { get; }
    public string Name { get; set; }
    public int Level {  get; set; }
    public int maxHp { get; set; }
    public int curHp {  get; set; }
    public int Atk {  get; set; }
    public int Def { get; set; }
    public int Spd {  get; set; }

    public CharacterBase()
    {

    }

    public CharacterBase(UnitType unitType, string name, int level, int maxHp, int curHp, int atk, int def, int spd)
    {
        this.unitType = unitType;
        Name = name;
        Level = level;
        this.maxHp = maxHp;
        this.curHp = curHp;
        Atk = atk;
        Def = def;
        Spd = spd;
    }

    public CharacterBase SetStatus(UnitType unitType)
    {
        CharacterBase status = null;

        switch (unitType)
        {
            case UnitType.Player:

                break;

            case UnitType.Normal:

                break;

            case UnitType.Elite:

                break;

            case UnitType.Boss:

                break;
        }

        return status;
    }

    
}
