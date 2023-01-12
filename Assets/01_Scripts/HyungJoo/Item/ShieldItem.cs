using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : MonoBehaviour
{
    void Awake()
    {
        Destroy(gameObject,10f);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
<<<<<<< HEAD
            PlayerController.DoShield();
            other.gameObject.transform.Find("BubbleSound").GetComponent<AudioSource>()?.Play();
            Debug.Log("BubbleSound");
=======
            other.gameObject.GetComponent<PlayerController>().shieldAction?.Invoke();
>>>>>>> parent of f2b5589 (Ｂｕｂｂｌｅ)
            Destroy(gameObject);
        }
    }
}
