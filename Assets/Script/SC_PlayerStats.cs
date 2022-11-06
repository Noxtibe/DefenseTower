using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlayerStats : MonoBehaviour
{
    [SerializeField] public static int money;
    [SerializeField] public int startMoney = 500;
    [SerializeField] public static int health;
    [SerializeField] public int startHealth = 20;

    public void Start()
    {
        money = startMoney;
        health = startHealth;
    }
}
