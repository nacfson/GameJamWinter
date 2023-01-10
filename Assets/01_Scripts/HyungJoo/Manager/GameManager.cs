using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
<<<<<<< HEAD
=======
    public UnityAction PlayerDead;
    public bool canMove;
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
>>>>>>> main
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
<<<<<<< HEAD
=======
        PlayerDead += PlayPlayerDead;
        canMove = false;
    }
>>>>>>> main

    }
}
