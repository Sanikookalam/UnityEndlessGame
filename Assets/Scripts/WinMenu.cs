using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    public string mainMenuLevel;

    public void RestartGame()
    {
        //FindObjectOfType<GameManager>().Reset();
    }

    public void QuitToMain()
    {
        //Application.LoadLevel(mainMenuLevel);
    }
}
