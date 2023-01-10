using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;
public class EndManager : MonoBehaviour
{
    public GameObject _endPanel;
    private GameObject _destination;
    [SerializeField] private TextMeshProUGUI _currentScore;
    [SerializeField] private TextMeshProUGUI _bestScore;

    
    private void Awake() {
        GameManager.Instance.PlayerDead -= PanelDown;
        _destination = GameObject.Find("Destination");
        _currentScore = transform.Find("CurrentScore").GetComponent<TextMeshProUGUI>();
        _bestScore = transform.Find("BestScore").GetComponent<TextMeshProUGUI>();
        GameManager.Instance.PlayerDead += PanelDown;

    }
    public void PanelDown()
    {
        _endPanel = this.gameObject;
        _endPanel.transform.DOLocalMoveY(-1f,0.4f).SetEase(Ease.Linear);
        _currentScore.text = $"{ScoreManager.score}M";
        _bestScore.text = $"BEST : {PlayerPrefs.GetInt("BESTSCORE")}M";
    }
    public void OnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GameManager.Instance.GameStart?.Invoke();
    }
    public void Restart()
    {
        GameManager.Instance.LoadPlayScene();
        GameManager.Instance.GameStart?.Invoke();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
