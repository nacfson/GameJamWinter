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
    [SerializeField]
    private Sprite _originVolumeSprite;
    [SerializeField]
    private Sprite _mutedVolumeSprite;
    [SerializeField]
    private Button _volumeChangeButton;
    
    public AudioMixer audioMixer;

    public Slider audioSlider;
    public bool onMainPanel;
    public bool onMaxVolume;
    public void ControlVolume()
    {
        float sound = audioSlider.value;
        if(sound == -40f) audioMixer.SetFloat("Master",-80f);
        else audioMixer.SetFloat("Master",sound);
    }

    public void OnVolumeMaxMin()
    {
        if(onMaxVolume)
        {
            audioMixer.SetFloat("Master",-80f);
            audioSlider.value = -40f;
            _volumeChangeButton.GetComponent<Image>().sprite = _mutedVolumeSprite;
            onMaxVolume = false;
        }
        else
        {
            audioMixer.SetFloat("Master",0f);
            audioSlider.value = 0f;
            _volumeChangeButton.GetComponent<Image>().sprite = _originVolumeSprite;
            onMaxVolume = true;

        }
    }
    private void Awake() {
        onMainPanel =false;
        Time.timeScale = 1f;
        _mainPanel.SetActive(false);
        _optionButton.SetActive(true);
        onMaxVolume = true;
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
