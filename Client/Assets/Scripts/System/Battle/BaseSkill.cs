using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class BaseSkill : MonoBehaviour
{
    public string skill1Name;
    public string skill2Name;
    public string skill3Name;
    public string skill4Name;
    public string skill1Description;
    public string skill2Description;
    public string skill3Description;
    public string skill4Description;
    public float skill1BaseDMG; 
    public float skill2BaseDMG; 
    public float skill3BaseDMG; 
    public float skill4BaseDMG; 
    public float S1BaseCD;
    public float S2BaseCD;
    public float S3BaseCD;
    public float S4BaseCD;
    public abstract float skill1DmgFormula(HeroBase myinfo);
}
