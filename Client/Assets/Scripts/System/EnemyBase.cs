using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyBase
{
    public string name;
    public float level;
    public float baseHP;
    public float currentHP;
    public float baseAtk;
    public float currentAtk;
    public float baseDef;
    public float currentDef;
    public enum EleType { FIRE, WATER, EARTH, WIND, DARK, LIGHT }
    public EleType EnemyEle;
}
