using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SP;
using TMPro;

public class ShowMoney : MonoBehaviour
{
    TextMeshProUGUI tmesh;
    int monies = 0;
    private void Awake()
    {
        tmesh = GetComponent<TextMeshProUGUI>();
        monies = GameManager.GetMoneyManager().currentMonies;
        tmesh.text = "You Stole $" + string.Format("{0:#,###0}", monies) + "!";
    }
}
