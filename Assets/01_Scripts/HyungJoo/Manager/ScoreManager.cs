using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _bestText;
    [SerializeField]
    private TextMeshProUGUI _currentText;
    public static int score;
    void Awake()
    {
        StartCoroutine(SetTextCor());
        GameManager.Instance.PlayerDead += SetScore;
        score  = 0;
    }
    IEnumerator SetTextCor()
    {
        yield return new WaitForSeconds(1f);
        while(true)
        {
            if(GameManager.Instance.playerScore != null)
                score = GameManager.Instance.playerScore.CheckHeight();
            _currentText.text = $"{score}M";
            _bestText.text = $"BEST {PlayerPrefs.GetInt("BESTSCORE")}M";
            SetScore();
            yield return null;
        }
    }

    public void SetScore()
    {
        if(score > PlayerPrefs.GetInt("BESTSCORE"))
        {
            PlayerPrefs.SetInt("BESTSCORE",GameManager.Instance.playerScore.CheckHeight());
        }
    }


}
