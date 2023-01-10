using System.Diagnostics.SymbolStore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionSceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainPanel;
    [SerializeField]
    private GameObject _optionButton;
    
    public AudioMixer audioMixer;

    public Slider audioSlider;
    public bool onMainPanel;
    public void ControlVolume()
    {
        float sound = audioSlider.value;
        if(sound == -40f) audioMixer.SetFloat("Master",-80f);
        else audioMixer.SetFloat("Master",sound);
    }
    private void Awake() {
        onMainPanel =false;
        Time.timeScale = 1f;
        _mainPanel.SetActive(false);
        _optionButton.SetActive(true);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OnLoadOption();
        }
    }
    public void OnLoadOption()
    {
        if(onMainPanel)
        {
            _mainPanel.SetActive(false);
            Time.timeScale = 1f;
        _optionButton.SetActive(true);

            onMainPanel = false;
        }
        else
        {
            _mainPanel.SetActive(true); 
            onMainPanel = true;
        _optionButton.SetActive(false);

            Time.timeScale = 0f;

        }
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GameManager.Instance.GameStart?.Invoke();

    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnSns()
    {
        Application.OpenURL("https://github.com/nacfson/GameJamWinter");
    }
}
