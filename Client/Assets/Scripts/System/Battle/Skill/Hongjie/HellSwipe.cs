using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellSwipe : BaseSkill
{
    public HellSwipe() {
        skillName = "Hell Swipe";
        skillDescription = "Summons a magic scythe from hell, Hongjie sweep the swipe forward, damaging an enemy and steal their lifeforce.";
        skillBaseDMG = 0.6f;
        skillCooldown = 6;
    }
}
