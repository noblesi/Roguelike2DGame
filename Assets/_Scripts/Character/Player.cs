using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : CharacterBase
{
    public float fortune {  get; set; }
    public float critRate {  get; set; }
    public float critDmg {  get; set; }
    public int maxExp {  get; set; }
    public int curExp {  get; set; }

    private bool isDead = false;

    public Player(UnitType unitType, string name, int level, int maxHp, int curHp, int atk, int def, int spd)
        : base(unitType, name, level, maxHp, curHp, atk, def, spd)
    {
        fortune = 0f;
        critRate = 0.15f;
        critDmg = 0.5f;
    }

    public int DamageToMonsters(Monster monster)
    {
        int baseDamage = Atk;
        float damage;
        bool isCritical = (Random.value < critRate);
        
        if(isCritical)
        {
            damage = baseDamage * (1 + critDmg);
        }
        else
        {
             damage = baseDamage;
        }

        int finalDamage = Mathf.Max(Mathf.RoundToInt(damage - monster.Def), 0);

        return finalDamage;
    }

    public void LevelUp()
    {
        if(curExp == maxExp)
        {
            Level++;
            maxExp += 150;
        }
    }

    public void Dead()
    {

    }
}
