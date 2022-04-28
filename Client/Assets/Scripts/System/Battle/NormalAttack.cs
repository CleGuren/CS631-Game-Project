using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttack : BaseSkill
{
    // public override float skill1BaseDMG { get { return 0.3f; } }
    // public override float skill2BaseDMG { get { return 0.4f; } }
    // public override float skill3BaseDMG { get { return 0.6f; } }
    // public override float skill4BaseDMG { get { return 0.9f; } }
    
    public NormalAttack() {
        skillName = "Normal Attack";
        skillDescription = "A regular smack comes a long way.";
        skillBaseDMG = 0.3f;
        // S1BaseCD = 3f;
        // skill2Name = "Fire Breath";
        // skill2Description = "General Gizlavof engulfs the land with his wide range fire breadth, damaging anyone in the vicinity.";
        // S2BaseCD = 3f;
        // skill3Name = "Gargantulant Bite";
        // skill3Description = "Chomp that ass cuz its no different than a juicy cake.";
        // S3BaseCD = 3f;
        // skill4Name = "Eye Beam";
        // skill4Description = "What's a demon if it doesn't have a eye lazer beam?";
        // S4BaseCD = 5f;
    }
}
