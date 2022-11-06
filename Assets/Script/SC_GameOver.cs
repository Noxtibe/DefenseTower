using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SC_GameOver : MonoBehaviour
{
    public TMP_Text wavesText;

    public void OnEnable()
    {
        wavesText.text = SC_PlayerStats.waves.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quit game !");
        Application.Quit();
    }
}
