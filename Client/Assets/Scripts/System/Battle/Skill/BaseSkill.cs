using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class BaseSkill : MonoBehaviour
{
    public string skillName;
    public string skillDescription;
    public float skillBaseDMG;
    public Sprite skillIcon;
    public int skillCooldown;
}
