using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;
public class EndManager : MonoBehaviour
{
    public GameObject _endPanel;
    private GameObject _destination;
    [SerializeField] private TextMeshProUGUI _currentScore;
    [SerializeField] private TextMeshProUGUI _bestScore;

    public float fadeTime = 1f;
    public CanvasGroup canvasGroup;
    public RectTransform rectTransform;
    public List<GameObject> items = new List<GameObject>();

    public void PanelFadeIn()
    {
        canvasGroup.alpha = 0f;
        rectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1, fadeTime);
        StartCoroutine("ItemsAnimation");
    }

    IEnumerator PanelFadeOut()
    {
        canvasGroup.alpha = 1f;
        rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, -2000f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(1, fadeTime);
        yield return new WaitForSeconds(1f);
        GameManager.Instance.LoadPlayScene();
        GameManager.Instance.GameStart?.Invoke();
        yield return null;
    }
    IEnumerator PanelFadeOutOnMainMenu()
    {
        canvasGroup.alpha = 1f;
        rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, -2000f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(1, fadeTime);
        yield return new WaitForSeconds(1f);
        GameManager.Instance.GoToMainMenu();
        GameManager.Instance.GameStart?.Invoke();
        yield return null;
    }

    IEnumerator ItemsAnimation()
    {
        foreach (var item in items)
        {
            item.transform.localScale = Vector3.zero;
        }
        foreach (var item in items)
        {
            item.transform.DOScale(1f, fadeTime).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(0.3f);
        }
    }
    private void Awake() {
        _destination = GameObject.Find("Destination");
        _currentScore = transform.Find("CurrentScore").GetComponent<TextMeshProUGUI>();
        _bestScore = transform.Find("BestScore").GetComponent<TextMeshProUGUI>();
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();

    }
    void Start()
    {
        GameManager.Instance.PlayerDead += PanelDown;
    }
    public void PanelDown()
    {
        GameManager.Instance.PlayerDead -= PanelDown;
        // _endPanel = this.gameObject;
        // _endPanel.transform.DOLocalMoveY(-1f,0.8f).SetEase(Ease.Linear);
        PanelFadeIn();
        _currentScore.text = $"{ScoreManager.score}M";
        _bestScore.text = $"BEST : {PlayerPrefs.GetInt("BESTSCORE")}M";

    }
    public void OnMainMenu()
    {
        StopCoroutine(PanelFadeOutOnMainMenu());
        StartCoroutine(PanelFadeOutOnMainMenu());


    }
    public void Restart()
    {
        StopCoroutine(PanelFadeOut());
        StartCoroutine(PanelFadeOut());
    }
    public void Quit()
    {
        Application.Quit();
    }
}
