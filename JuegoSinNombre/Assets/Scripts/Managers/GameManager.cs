using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int _actualLevel = 0;
    public Vector3 checkpointPlayerPosition;
    bool _isPause = false;
    public GameObject player;
    static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }


    private void Awake()
    {
        _instance = this;
    }

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
        ChangeScene("Level0");
    }

    public void NextLevel()
    {
        ChangeScene($"Level{_actualLevel}");
    }

    public void BackToMainMenu()
    {
        ChangeScene("MainMenu");
    }
    
    public void Quit()
    {
        Application.Quit();
    }

    public void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    #endregion
}
