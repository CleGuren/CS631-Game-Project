using System.Collections;
using UnityEngine;

public class SwordSlash : BaseSkill
{
    public SwordSlash() {
        skillName = "Sword Slash";
        skillDescription = "Alexiel smashes her sword downward, dealing damage.";
        skillBaseDMG = 0.3f;
        skillCooldown = 3;
    }
}
