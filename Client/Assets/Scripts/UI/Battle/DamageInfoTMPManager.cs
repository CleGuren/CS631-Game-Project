using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageInfoTMPManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TMP;
    [SerializeField] private Animator animator;

    public void setDamage(int amount)
    {
        TMP.text = amount.ToString();
    }

    public void show(string animation)
    {
        animator.SetTrigger(animation);
    }

    public void destroy()
    {
        Destroy(this.gameObject);
    }
}
