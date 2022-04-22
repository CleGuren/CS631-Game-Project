using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HeroBase
{
    public string charName;
    public Sprite charPortrait;
    public float level;
    public float baseHP;
    public float currentHP;
    public float maxHP;
    public float baseAtk;
    public float currentAtk;
    public float baseDef;
    public float currentDef;
    public enum EleType { FIRE, WATER, EARTH, WIND, DARK, LIGHT }
    public enum WeaponType { SWORD, DAGGER, STAFF, AXE }
    public EleType HeroEle;
    public WeaponType HeroPrefWeapon;
}
