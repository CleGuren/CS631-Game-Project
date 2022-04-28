using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyBase
{
    public string enemyName;
    public float level;
    public float baseHP;
    public float currentHP;
    public float maxHP;
    public float baseAtk;
    public float currentAtk;
    public float baseDef;
    public float currentDef;
    public int ChargeDiamond;
    public enum EleType { FIRE, WATER, EARTH, WIND, DARK, LIGHT }
    public EleType EnemyEle;
    public List<BaseSkill> mySkill;
}
