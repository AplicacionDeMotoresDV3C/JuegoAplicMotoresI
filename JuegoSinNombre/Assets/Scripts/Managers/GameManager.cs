using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Vector3 checkpointPlayerPosition;

    bool _isPause = false;

    private void Start()
    {
        checkpointPlayerPosition = player.transform.position;
    }


    #region PLAYER
    public void SavePosition()
    {
        checkpointPlayerPosition = player.transform.position;
    }

    public void LoadPosition()
    {
        player.transform.position = checkpointPlayerPosition;
    }
    #endregion

    #region GAMEPLAY_UI
    public void Pause()
    {
        _isPause = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        _isPause = false;
        Time.timeScale = 1;
    }
    #endregion

    #region GAMEPLAY_FLOW
    public void NewGame()
    {

    }

    public void NextLevel()
    {

    }

    public void BackToMainMenu()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
    #endregion
}
