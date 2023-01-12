using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCollision : MonoBehaviour
{
    [SerializeField]
    public TrashSO trashSO;
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
<<<<<<< HEAD
                PlayerController.UnDoShield();
<<<<<<< HEAD
                bubbleSound?.Play();
=======
                PlayerController.onShield = false;
>>>>>>> parent of f2b5589 (Ｂｕｂｂｌｅ)
=======

>>>>>>> parent of 52a678c (dd)
                Destroy(gameObject);
                return;
            }
            GameManager.Instance.PlayerDead?.Invoke();

        }
    }
}
