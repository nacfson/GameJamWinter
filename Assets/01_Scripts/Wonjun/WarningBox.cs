using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningBox : MonoBehaviour
{
    [SerializeField]
    public TrashSO trashSO;
    
    //public float RanWall = Random.Range(3f, 10f);
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destruction",10f);
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (GameManager.canMove)
        {
            transform.position -= new Vector3(0, trashSO.fallSpeed * 0.05f);
            transform.Rotate(new Vector3(0, 0, trashSO.rotationSpeed * 10f));
        }

    }
    public void Destruction()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.PlayerDead?.Invoke();
            Destruction();
        }
    }
}
