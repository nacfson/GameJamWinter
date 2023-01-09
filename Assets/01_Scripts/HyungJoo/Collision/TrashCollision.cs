using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCollision : MonoBehaviour
{
    public float speed = 0.2f;

    private void FixedUpdate() {
        transform.position -= new Vector3(0,speed * 0.05f);
        transform.Rotate(new Vector3(0,0,speed * 10f));
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
