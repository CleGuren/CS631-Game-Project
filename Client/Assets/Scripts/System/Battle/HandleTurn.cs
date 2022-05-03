using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HandleTurn
{
    public string attackerName; //Name of attacker
    public string Type;
    public GameObject Attacker; //Who is attacking
    public GameObject Target; //The target
    public int MA_Data;

    //which attack is performed
    public BaseSkill chosenAtk;
}
