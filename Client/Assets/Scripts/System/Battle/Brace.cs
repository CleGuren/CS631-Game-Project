using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brace : BaseSkill
{
    public Brace() {
        skillName = "Brace";
        skillDescription = "Alexiel braces herself, mitigating incoming damage by 60%";
        skillBaseDMG = 0.6f;
    }
}
