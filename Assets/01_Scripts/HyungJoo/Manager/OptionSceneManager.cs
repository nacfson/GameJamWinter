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
        GameManager.Instance.canMove = false;
        _mainPanel.SetActive(false);
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
            onMainPanel = false;
        }
        else
        {
            _mainPanel.SetActive(true); 
            onMainPanel = true;
            Time.timeScale = 0f;

        }
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
