using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCollision : MonoBehaviour
{
    [SerializeField]
    public TrashSO trashSO;
    public AudioSource bubbleSound;
    void Awake()
    {
        Invoke("Destruction",10f);
    }
    public void Destruction()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate() {
        if(GameManager.canMove)
        {
            transform.position -= new Vector3(0,trashSO.fallSpeed * 0.05f);
            transform.Rotate(new Vector3(0,0,trashSO.rotationSpeed * 10f));
        }

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            if(PlayerController.onShield)
            {
                PlayerController.UnDoShield();
                bubbleSound?.Play();
                Destroy(gameObject);
                return;
            }
            GameManager.Instance.PlayerDead?.Invoke();

        }
    }
}
