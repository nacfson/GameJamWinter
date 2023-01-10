using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    void Start(){
        //Invoke("Destruction",10f);
    }
    public void Destruction()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.CompareTag("Player"))
        {
            GameManager.Instance.PlayerDead?.Invoke();
            Destruction();
        }
    }
}
