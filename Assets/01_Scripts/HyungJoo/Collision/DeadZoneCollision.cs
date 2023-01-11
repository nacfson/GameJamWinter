using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DeadZoneCollision : MonoBehaviour
{
    public float upSpeed = 0.05f;
    public bool canMove;
    void Awake()
    {
        canMove = false;
    }
    private void FixedUpdate() {
        if(GameManager.canMove)
        {
            
            float speed = 1;
            if(ScoreManager.score < 100)
            {
                speed = 1 + ScoreManager.score * 0.01f;
            }
            transform.position += Vector3.up * upSpeed * 0.5f * speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.CompareTag("Player"))
        {
            GameManager.Instance.PlayerDead?.Invoke();

        }
    }
}
