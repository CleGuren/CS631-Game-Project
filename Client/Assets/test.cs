using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private DamageDisplayManager DDM;
    // Start is called before the first frame update
    private IEnumerator Start()
    {
        if (DDM)
        {
            while (true)
            {
                DDM.displayDamage(100.5f);
                yield return new WaitForSeconds(3);
            }
        }

        yield return null;
    }
}
