using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometRain : BaseSkill
{
    public CometRain() {
        skillName = "Comet Rain";
        skillDescription = "Melinda summons a downpour of icy comets, damaging all enemies.";
        skillBaseDMG = 0.4f;
        skillCooldown = 3;
    }
}
