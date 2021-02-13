using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    public string mainMenuLevel;

    public void RestartGame()
    {
        
    }

    public void QuitToMain()
    {
        Application.LoadLevel(mainMenuLevel);
    }
}
