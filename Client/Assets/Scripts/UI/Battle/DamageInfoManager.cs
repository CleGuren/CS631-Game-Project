using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInfoManager : MonoBehaviour
{
    public void setDamage(int amount)
    {
        TextMesh textMesh = this.GetComponent<TextMesh>();
        textMesh.text = amount.ToString();
    }

    public void show(string animation)
    {
        Animator animator = this.gameObject.GetComponent<Animator>();
        animator.SetTrigger(animation);
    }

    public void destroy()
    {
        Destroy(this.gameObject);
    }
}
