using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public UnityAction PlayerDead;
    public UnityAction GameStart;
    public UnityAction PlayerAnimationEnd;
    public bool canMove;
    public bool canSpawn;
    public ScoreManager _scoreManager;

    public PlayerScore _playerScore;
    public PlayerScore playerScore
    {
        get
        {
            _playerScore = FindObjectOfType<PlayerScore>();
            return _playerScore;
        }
    }
    public ScoreManager scoreManager
    {
        get
        {
            _scoreManager = FindObjectOfType<ScoreManager>();
            return _scoreManager;
        }
    }
    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        PlayerDead -= PlayPlayerDead;
        PlayerDead += PlayPlayerDead;
        GameStart = Destruction;
        canMove = false;
    }

    public void PlayPlayerDead()
    {
        Debug.Log("PlayerDead");
        Handheld.Vibrate();
        canMove = false;
        canSpawn = false;
    }
    public void LoadPlayScene()
    {
        SceneManager.LoadScene("PlayScene");
        OnLoadUIScenes();
    }
    public void OnLoadUIScenes()
    {
        SceneManager.LoadScene("OptionScene",LoadSceneMode.Additive);
        SceneManager.LoadScene("Score",LoadSceneMode.Additive);
    }
    public void Destruction()
    {
        Destroy(gameObject);
    }
}
