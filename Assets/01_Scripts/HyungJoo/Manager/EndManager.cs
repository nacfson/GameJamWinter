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
        _destination = GameObject.Find("Destination");
        _currentScore = transform.Find("CurrentScore").GetComponent<TextMeshProUGUI>();
        _bestScore = transform.Find("BestScore").GetComponent<TextMeshProUGUI>();
        _endPanel = this.gameObject;
        GameManager.Instance.PlayerDead += PanelDown;

    }
    public void PanelDown()
    {
        _endPanel.transform.DOLocalMoveY(-1f,1f);
        _currentScore.text = $"{ScoreManager.score}M";
        _bestScore.text = $"BEST : {PlayerPrefs.GetInt("BESTSCORE")}M";
        GameManager.Instance.PlayerDead -= PanelDown;
    }
    public void OnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Restart()
    {
        GameManager.Instance.LoadPlayScene();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
