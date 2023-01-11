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
			flashingText.text = "TAP TO START";
			yield return new WaitForSeconds (.3f);
		}
	}
}