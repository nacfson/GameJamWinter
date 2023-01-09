using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _bestText;
    [SerializeField]
    private TextMeshProUGUI _currentText;
    void Awake()
    {
        StartCoroutine(SetTextCor());
        GameManager.Instance.PlayerDead += SetScore;
    }
    IEnumerator SetTextCor()
    {
        yield return new WaitForSeconds(1f);
        while(true)
        {
            _currentText.text = $"{GameManager.Instance.playerScore.CheckHeight()}M";
            _bestText.text = $"BEST {PlayerPrefs.GetInt("BESTSCORE")}M";   
            yield return null;
        }
    }

    public void SetScore()
    {
        if(GameManager.Instance.playerScore.CheckHeight() > PlayerPrefs.GetInt("BESTSCORE"))
        {
            PlayerPrefs.SetInt("BESTSCORE",GameManager.Instance.playerScore.CheckHeight());
        }
    }

}
