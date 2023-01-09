using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _exitPanel;

    public bool onExitPanel;
    void Awake()
    {
        _exitPanel.SetActive(false);
        onExitPanel = false;

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
}
