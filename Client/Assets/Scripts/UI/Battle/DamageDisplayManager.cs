using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDisplayManager : MonoBehaviour
{
    [SerializeField] private GameObject dmgPrefab;
    [SerializeField] private Transform spawnArea;

    public void displayDamage(float dmg)
    {
        GameObject newDmg = Instantiate(dmgPrefab, Vector3.zero, Quaternion.identity, spawnArea) as GameObject;
        newDmg.transform.localPosition = Vector3.zero;

        DamageInfoTMPManager dmgInfoTMPManager = newDmg.GetComponent<DamageInfoTMPManager>();
        // Set Dmg Number
        dmgInfoTMPManager.setDamage((int)dmg);
        // Show Dmg
        dmgInfoTMPManager.show("fade");
    }
}
