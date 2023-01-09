using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OptionSceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainPanel;
    public bool onMainPanel;
    private void Awake() {
        onMainPanel =false;
        _mainPanel.SetActive(false);
    }

    public void OnLoadOption()
    {
        if(onMainPanel)
        {
            _mainPanel.SetActive(false);
            onMainPanel = false;
        }
        else
        {
            _mainPanel.SetActive(true);
            onMainPanel = true;
        }
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
