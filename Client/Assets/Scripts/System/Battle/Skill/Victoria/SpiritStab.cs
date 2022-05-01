using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritStab : BaseSkill
{
    public SpiritStab() {
        skillName = "Spirit Stab";
        skillDescription = "Gather the spirit of her victims, Victoria strikes a deadly blow.";
        skillBaseDMG = 0.6f;
        skillCooldown = 4;
    }
}
