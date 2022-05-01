using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttack : BaseSkill
{
    public NormalAttack() {
        skillName = "Normal Attack";
        skillDescription = "A regular smack comes a long way.";
        skillBaseDMG = 0.3f;
        skillCooldown = 0;
    }
}
