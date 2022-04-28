using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeDiamond : MonoBehaviour
{
    public Transform[] ChargeDiamondBox;
    public List<GameObject> DiamondContainer;
    public Sprite RedDiamond;
    public Sprite GreyedDiamond;
    private int DiamondTracker;

    void Start() {
        DiamondContainer = new List<GameObject>();
        ChargeDiamondBox = GetComponentsInChildren<Transform>();
        foreach (Transform Diamond in ChargeDiamondBox) {
            DiamondContainer.Add(Diamond.gameObject);
        }
        DiamondTracker = 1;
    }

    public void HideDiamonds() {
        for (int i = 1; i < DiamondContainer.Count; i++) {
            DiamondContainer[i].SetActive(false);
        }
    }

    public void SetDiamonds(int DiamondCount) {
        for (int i = 1; i <= DiamondCount; i++) {
            DiamondContainer[i].SetActive(true);
        }
    }

    public void GainDiamond() { 
        DiamondContainer[DiamondTracker].GetComponent<Image>().sprite = RedDiamond;
        DiamondTracker++;
    }

    public void ResetDiamond() {
        for (int i = 1; i < DiamondTracker; i++) {
            DiamondContainer[i].GetComponent<Image>().sprite = GreyedDiamond;
        }
        DiamondTracker = 1;
    }
}
