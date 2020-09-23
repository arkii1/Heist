using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SP.UI
{
    public class MoneyText : UIElement
    {
        int currentMonies = 0;

        TextMeshProUGUI tmesh;

        public override void Init()
        {
            tmesh = GetComponent<TextMeshProUGUI>();

            currentMonies = 0;
            UpdateText();
        }

        public override void Tick(float delta)
        {
            currentMonies = GameManager.GetMoneyManager().currentMonies;
            UpdateText();
        }

        void UpdateText()
        {
            tmesh.text = "$" + string.Format("{0:#,###0}", currentMonies);
        }
    }
}

