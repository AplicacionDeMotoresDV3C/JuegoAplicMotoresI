using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int _nextLevel = 0;
    //[SerializeField] Vector3 checkpointPlayerPosition;
    public bool _isPause = false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] GameObject victoryCanvas;
    public GameObject player;
    [SerializeField] Player _playerData;
    static GameManager _instance;
    bool playerWins;
    CheckpointStruct checkpointData = new CheckpointStruct();
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }


    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        if(player != null)
        {
            _playerData.enabled = true;
            _playerData.Health.SetHealth();
            player.GetComponent<Collider2D>().enabled = true;
            SavePosition();
            Debug.Log("Start " + checkpointData.playerLife);
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isPause = !_isPause;
            Pause();
        }

        Debug.Log("Update Gamemanager " + checkpointData.playerLife);
        
    }

    #region PLAYER
    public void SavePosition()
    {
        checkpointData.checkpointPosition = player.transform.position;
        checkpointData.playerLife = _playerData.Health.GetHealth();
        Debug.Log("Vida checkpoin Data " + checkpointData.playerLife);
    }

    public void LoadPosition()
    {
        player.transform.position = checkpointData.checkpointPosition;
        _playerData.Health.AssignHealth(checkpointData);
    }
    #endregion

    #region GAMEPLAY_UI
    public void Pause()
    {
        
        if (_isPause)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }

    }

    public void Resume()
    {
        _isPause = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);

    }
    #endregion

    #region GAMEPLAY_FLOW
    public void NewGame()
    {
        Time.timeScale = 1;
        ChangeScene("Level0");
    }

    public void NextLevel()
    {
        ChangeScene($"Level{_nextLevel}");
    }

    public void BackToMainMenu()
    {
        ChangeScene("MainMenu");
    }

    public void Restart()
    {
        Time.timeScale = 1;
        gameOverCanvas.SetActive(false);
        LoadPosition();
    }

    public void Quit()
    {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif

    }

    public void ChangeScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void GameOver()
    {
        playerWins = false;
        StartCoroutine(WaitForSeconds());   
    }

    public void Victory()
    {
        playerWins = true;
        StartCoroutine(WaitForSeconds());   
    }

    #endregion

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(2.5f);
        if (playerWins)
            victoryCanvas.SetActive(true);
        else
        {
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
