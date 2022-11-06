using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_GameManager : MonoBehaviour
{
    private bool gameEnded = false;

    void Update()
    {
        if(gameEnded)
        {
            return;
        }

        if (SC_PlayerStats.health <= 0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        gameEnded = true;
        Debug.Log("Game Over...");
    }
}
