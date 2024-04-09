using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : CharacterBase
{
    public Monster(UnitType unitType, string name, int level, int maxHp, int curHp, int atk, int def, int spd)
        : base(unitType, name, level, maxHp, curHp, atk, def, spd)
    {

    }

    public int DamageToPlayer(Player player)
    {
        return Mathf.Max((int)Atk - player.Def, 0);
    }
}
