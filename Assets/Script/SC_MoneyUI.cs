using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SC_MoneyUI : MonoBehaviour
{
    public TMP_Text moneyText;

    void Update()
    {
        moneyText.text = SC_PlayerStats.money.ToString() + "€"; 
    }
}
