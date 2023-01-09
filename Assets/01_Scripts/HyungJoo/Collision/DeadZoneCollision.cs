using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DeadZoneCollision : MonoBehaviour
{
    public float upSpeed = 0.05f;

    private void FixedUpdate() {
        transform.position += Vector3.up * upSpeed * 0.01f;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.CompareTag("Player"))
        {
            GameManager.Instance.PlayerDead?.Invoke();

        }
    }
}
