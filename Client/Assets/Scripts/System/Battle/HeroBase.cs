using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HeroBase
{
    public string charName;
    public Sprite charPortrait;
    public Sprite skill1_img;
    public Sprite skill2_img;
    public Sprite skill3_img;
    public Sprite skill4_img;
    public float skill1_cd;
    public float skill2_cd;
    public float skill3_cd;
    public float skill4_cd;
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
    public List<BaseSkill> mySkill;
}
