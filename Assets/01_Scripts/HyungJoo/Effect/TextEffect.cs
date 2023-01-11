using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class TextEffect : MonoBehaviour {

	TextMeshProUGUI flashingText;

	// Use this for initialization
	void Start () {
		flashingText = GetComponent<TextMeshProUGUI>();
		StartCoroutine (BlinkText());
	}

	public IEnumerator BlinkText(){
		while (true) {
			flashingText.text = "";
			yield return new WaitForSeconds (.2f);
			flashingText.text = "화면을 탭하여 게임을 시작";
			yield return new WaitForSeconds (.3f);
		}
	}
}