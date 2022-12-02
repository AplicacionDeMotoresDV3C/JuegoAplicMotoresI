using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int _nextLevel = 0;
    public Vector3 checkpointPlayerPosition;
    public bool _isPause = false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] GameObject victoryCanvas;
    public GameObject player;
    static GameManager _instance;
    bool playerWins;
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
            checkpointPlayerPosition = player.transform.position;
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
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);
        ChangeScene(scene.name);
    }

    public void Quit()
    {
        Application.Quit();
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
