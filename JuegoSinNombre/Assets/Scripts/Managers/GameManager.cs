using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int _actualLevel = 0;
    public Vector3 checkpointPlayerPosition;
    public bool _isPause = false;
    [SerializeField] GameObject menuPausa;
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
            menuPausa.SetActive(true);
        }
        else
        {
            menuPausa.SetActive(false);
            Time.timeScale = 1;
        }

    }

    public void Resume()
    {
        _isPause = false;
        Time.timeScale = 1;
        menuPausa.SetActive(false);

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

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);
        ChangeScene(scene.name);
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
