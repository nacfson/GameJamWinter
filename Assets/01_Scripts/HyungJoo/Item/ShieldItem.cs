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
            other.gameObject.GetComponent<PlayerController>().shieldAction?.Invoke();
            Destroy(gameObject);
        }
    }
}
