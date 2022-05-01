using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSweep : BaseSkill
{
    public SwordSweep() {
        skillName = "Sword Sweep";
        skillDescription = "Alexiel sweeps her sword in an arc, dealing damage to all enemies.";
        skillBaseDMG = 0.5f;
        skillCooldown = 5;
    }
}
