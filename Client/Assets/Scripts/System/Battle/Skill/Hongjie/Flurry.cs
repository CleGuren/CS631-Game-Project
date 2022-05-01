using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flurry : BaseSkill
{
    public Flurry() {
        skillName = "Flurry";
        skillDescription = "Swinging wildly, Hongjie damages anyone that caught in his path.";
        skillBaseDMG = 0.4f;
        skillCooldown = 5;
    }
}
