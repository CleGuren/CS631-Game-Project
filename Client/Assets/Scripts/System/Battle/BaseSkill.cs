using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class BaseSkill : MonoBehaviour
{
    public string skillName;
    // public string skill2Name;
    // public string skill3Name;
    // public string skill4Name;
    public string skillDescription;
    // public string skill2Description;
    // public string skill3Description;
    // public string skill4Description;
    public float skillBaseDMG;
    // public abstract float skill2BaseDMG { get; } 
    // public abstract float skill3BaseDMG { get; }
    // public abstract float skill4BaseDMG { get; }
    // public float S1BaseCD;
    // public float S2BaseCD;
    // public float S3BaseCD;
    // public float S4BaseCD;
    
    // public float skill1DmgFormula(HeroBase myinfo) {
    //     return myinfo.currentAtk * skill1BaseDMG + 100;
    // }

    // public float skill2DmgFormula(HeroBase myinfo) {
    //     return myinfo.currentAtk * skill2BaseDMG + 100;
    // }

    // public float skill3DmgFormula(HeroBase myinfo) {
    //     return myinfo.currentAtk * skill3BaseDMG + 100;
    // }

    // public float skill4DmgFormula(HeroBase myinfo) {
    //     return myinfo.currentAtk * skill4BaseDMG + 100;
    // }
}
