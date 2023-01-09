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

    public void SetText()
    {
        _currentText.text = $"{GameManager.Instance.playerScore.CheckHeight()}M";
        //_bestText.text = $"BEST {PlayerPrefs.GetInt("BESTSCORE")}M";   
    }
    void Update()
    {
        SetText();
    }
}
