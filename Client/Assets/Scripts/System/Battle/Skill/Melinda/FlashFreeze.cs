using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashFreeze : BaseSkill
{
    public FlashFreeze() {
        skillName = "Flash Freeze";
        skillDescription = "Melinda focuses her magic power and creates a giant block of ice under an enemy, damaging it.";
        skillBaseDMG = 0.8f;
        skillCooldown = 5;
    }
}
