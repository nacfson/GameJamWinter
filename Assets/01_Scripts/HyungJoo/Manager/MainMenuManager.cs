using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _exitPanel;
    [SerializeField]
    private TextMeshProUGUI _bestScoreText;
    [SerializeField]
    private GameObject _storePanel;
    [SerializeField]
    private Button _selectButton;
    [SerializeField]
    private Button _leftButton;
    [SerializeField]
    private Button _rightButton;
    [SerializeField]
    private Image _applyImage;
    public GameObject godeongu;

    public bool onExitPanel;
    public bool onStorePanel;
    public int listCount;
    public static int applyCount;

    public List<Image> catImageList = new List<Image>();
    void Awake()
    {
        listCount = 0;
        applyCount = 0;
        _exitPanel.SetActive(false);
        onExitPanel = false;
        _storePanel.SetActive(false);
        onStorePanel = false;
        godeongu.SetActive(true);
        UpdateUI();

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ExitPanel();
            _storePanel.SetActive(false);
        }
        //UpdateUI();

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
        if(onStorePanel)
        {
            _storePanel.SetActive(false);
            godeongu.SetActive(true);
            onStorePanel = false;
        }
        else
        {
            _storePanel.SetActive(true);
            onStorePanel = true;
            _bestScoreText.text = $"BEST SCORE\n{PlayerPrefs.GetInt("BESTSCORE")}M";
            godeongu.SetActive(false);

        }
    }
    public void OnLeftButton()
    {
        Debug.Log("Onleft");
        if(listCount > 0)
        {
            listCount--;
        }
        UpdateUI();
        
    }
    public void OnRightButton()
    {
        Debug.Log("Onleft");

        if(listCount < catImageList.Count)
        {
            listCount ++;
        }
        UpdateUI();
    }
    public void OnSelectButton()
    {
        applyCount = listCount;
    }
    public void UpdateUI()
    {
        Debug.Log(listCount);
        _applyImage.sprite = catImageList[listCount].sprite;

        switch(listCount)
        {
            case 0:
                _leftButton.interactable = false;
                _rightButton.interactable = true;

                break;
            case 1:
                _rightButton.interactable = false;
                _leftButton.interactable = true;
                break;
        }
    }
    
}
