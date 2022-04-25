using System.Collections;
using UnityEngine;

public class AlexielSkill : BaseSkill
{
    public AlexielSkill() {
        skill1Name = "Sword Smash";
        skill1Description = "Alexiel smashes her sword downward, dealing damage.";
        skill1BaseDMG = 0.3f;
        S1BaseCD = 3f;
        skill2Name = "Shield Bash";
        skill2Description = "Alexiel bashes her shield forward, dealing damage.";
        skill2BaseDMG = 0.4f;
        S2BaseCD = 3f;
        skill3Name = "Sword Pierce";
        skill3Description = "Alexiel pierces her sword into the enemy, dealing damage.";
        skill3BaseDMG = 0.6f;
        S3BaseCD = 5f;
        skill4Name = "Sword Sweep";
        skill4Description = "Alexiel sweeps her sword in an arc, dealing damage.";
        skill4BaseDMG = 0.9f;
        S4BaseCD = 6f;
    }

    public override float skill1DmgFormula(HeroBase myinfo) {
        return skill1BaseDMG * myinfo.currentAtk + 100;
    }
}
