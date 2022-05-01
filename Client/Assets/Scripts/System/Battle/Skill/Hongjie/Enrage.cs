using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enrage : BaseSkill
{
    public Enrage() {
        skillName = "Enrage";
        skillDescription = "Hongjie empowers himself, dealing more damage for a number of turns.";
        skillBaseDMG = 0.5f;
        skillCooldown = 6;
    }
}
