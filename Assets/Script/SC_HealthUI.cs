using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SC_HealthUI : MonoBehaviour
{
    public TMP_Text healthText;

    void Update()
    {
        healthText.text = SC_PlayerStats.health + " Health";
    }
}
