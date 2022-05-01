using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoodConcealed : BaseSkill
{
    public HoodConcealed() {
        skillName = "Hood Concealed";
        skillDescription = "An assassin stays within the shadow. For one turn, Victoria dodges all attack.";
        skillBaseDMG = 0.0f;
        skillCooldown = 6;
    }
}
