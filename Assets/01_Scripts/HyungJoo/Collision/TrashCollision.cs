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
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.CompareTag("Player"))
        {
            GameManager.Instance.PlayerDead?.Invoke();
            Destroy(gameObject);
            Debug.Log("TRASH");
        }
    }
}
