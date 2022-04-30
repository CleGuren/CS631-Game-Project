using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShield : BaseSkill
{
    public IceShield() {
        skillName = "Ice Shield";
        skillDescription = "With her magic ability, Melinda conjures an icy shield around her, increasing her defense and resistance to ice damage.";
        skillBaseDMG = 0.6f;
        skillCooldown = 5;
    }
}
