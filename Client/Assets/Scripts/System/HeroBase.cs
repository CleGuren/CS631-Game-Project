using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HeroBase
{
    public string name;
    public int level;
    public int baseHP;
    public int currentHP;
    public int baseAtk;
    public int currentAtk;
    public int baseDef;
    public int currentDef;
    public enum EleType { FIRE, WATER, EARTH, WIND, DARK, LIGHT }
    public enum WeaponType { SWORD, DAGGER, STAFF, AXE }
    public EleType HeroEle;
    public WeaponType HeroPrefWeapon;
}
