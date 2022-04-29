using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDisplayManager : MonoBehaviour
{
    [SerializeField] private GameObject dmgPrefab;

    public void displayDamage(float dmg)
    {
        GameObject newDmg = Instantiate(dmgPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        newDmg.transform.parent = this.gameObject.transform;

        DamageInfoManager dmgInfoManager = newDmg.GetComponent<DamageInfoManager>();
        // Set Dmg Number
        dmgInfoManager.setDamage((int)dmg);
        // Show Dmg
        dmgInfoManager.show("fade");
    }
}
