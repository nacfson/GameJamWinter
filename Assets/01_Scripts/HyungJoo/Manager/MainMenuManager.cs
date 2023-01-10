using System;
using UnityEngine;
using TMPro;
public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _exitPanel;
    [SerializeField]
    private TextMeshProUGUI _bestScoreText;
    [SerializeField]
    private GameObject _scorePanel;

    public bool onExitPanel;
    public bool onScorePanel;
    void Awake()
    {
        _exitPanel.SetActive(false);
        onExitPanel = false;
        _scorePanel.SetActive(false);
        onScorePanel = false;

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ExitPanel();
        }
    }


    public void OnStart()
    {
        GameManager.Instance.LoadPlayScene();
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnContinue()
    {
        ExitPanel();
    }

    public void ExitPanel()
    {
        if(onExitPanel)
        {
            _exitPanel.SetActive(false);
            onExitPanel = false;
        }
        else
        {
            _exitPanel.SetActive(true);
            onExitPanel = true;
        }
    }

    public void ScorePanel()
    {
        if(onScorePanel)
        {
            _scorePanel.SetActive(false);
            onScorePanel = false;
        }
        else
        {
            _scorePanel.SetActive(true);
            onScorePanel = true;
            _bestScoreText.text = $"BEST SCORE\n{PlayerPrefs.GetInt("BESTSCORE")}M";
        }
    }
}
