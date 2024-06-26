using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Cinemachine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public UnityAction PlayerDead;
    public UnityAction PlayerDeadPlayer;
    public UnityAction PlayerDeadEnd;
    public UnityAction PlayerDeadScore;
    public UnityAction GameStart;
    public UnityAction PlayerAnimationEnd;
    public static bool canMove;
    public static bool canSpawn;
    public ScoreManager _scoreManager;

    public PlayerScore _playerScore;
    public AudioSource ingameAudio;

    private CinemachineVirtualCamera _vCam;
    public CinemachineVirtualCamera VCam {
        get {
            if(_vCam == null) {
                _vCam = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
            }
            return _vCam;
        }
    }
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
        canMove = false;

    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        ingameAudio.Stop();
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
        ingameAudio.Play();
    }
    public void OnLoadUIScenes()
    {
        SceneManager.LoadScene("OptionScene",LoadSceneMode.Additive);

        SceneManager.LoadScene("Score",LoadSceneMode.Additive);
    }

}
