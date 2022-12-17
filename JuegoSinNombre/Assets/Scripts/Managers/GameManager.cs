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
    [SerializeField] CheckpointStruct checkpointData = new CheckpointStruct();
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
        SavePosition();
    }

    private void Start()
    {
        
        if(player != null)
        {
            //checkpointPlayerPosition = player.transform.position;
            _playerData.enabled = true;
            _playerData.Health.SetHealth();
            player.GetComponent<Collider2D>().enabled = true;
            LoadPosition();
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isPause = !_isPause;
            Pause();
        }
        
    }

    #region PLAYER
    public void SavePosition()
    {
        //checkpointPlayerPosition = player.transform.position;
        checkpointData.checkpointPosition = player.transform.position;
    }

    public void LoadPosition()
    {
        player.transform.position = checkpointData.checkpointPosition;
        Debug.Log(checkpointData.checkpointPosition.x);
        Debug.Log(checkpointData.checkpointPosition.y);
        //player.transform.position = checkpointPlayerPosition;
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
