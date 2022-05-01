using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezia : BaseSkill
{
    public Freezia() {
        skillName = "Freezia";
        skillDescription = "A master level spell. Melinda conjures a beam of icy energy on an enemy, dealing massive damage.";
        skillBaseDMG = 1.5f;
        skillCooldown = 6;
    }
}
