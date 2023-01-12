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
    public bool onMaxVolume;
    [SerializeField]
    private Button _volumeButton;
    [SerializeField]
    private Sprite _origin;
    [SerializeField]
    private Sprite _muted;
    public void ControlVolume()
    {
        float sound = audioSlider.value;
        Debug.Log("Sound");
        if(sound == -40f) 
        {
        Debug.Log("SoundInspector");

            _volumeButton.GetComponent<Image>().sprite = _muted;
            audioMixer.SetFloat("Master",-80f);
            onMaxVolume = false;
        }
        else
        {
            _volumeButton.GetComponent<Image>().sprite = _origin;
            Debug.Log("ssssss");
            audioMixer.SetFloat("Master",sound);

        }
            
    }
    private void Awake() {
        onMainPanel =false;
        Time.timeScale = 1f;
        _mainPanel.SetActive(false);
        _optionButton.SetActive(true);
        onMaxVolume = true;
        audioMixer.SetFloat("Master",0f);
        audioSlider.value = 0f;
    }
    public void OnVolumeMinMax()
    {
        if(onMaxVolume)
        {
            onMaxVolume = false;
            audioSlider.value = -40f;
            ControlVolume();

        }
        else
        {
            onMaxVolume = true;
            audioSlider.value = 0f;
            ControlVolume();
        }
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
        GameManager.Instance.GoToMainMenu();
        GameManager.Instance.GameStart?.Invoke();

    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnSns()
    {
        Application.OpenURL("https://www.instagram.com/hyung_ju1030/");
    }
}
