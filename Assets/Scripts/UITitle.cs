using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UITitle : GameBehaviour
{
    public GameObject OptionsPanel;
    public void Start()
    {
        OptionsPanel.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
        _GM.ChangeGameState(GameState.Playing);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
