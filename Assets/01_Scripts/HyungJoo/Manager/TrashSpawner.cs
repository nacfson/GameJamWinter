using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _trashObject;
    public Transform trashSpawner;
    public Transform playerTransform;
    public float spawnDelay;

    void Awake()
    {
        trashSpawner = this.transform;
        playerTransform = FindObjectOfType<PlayerController>().transform;
        GameManager.Instance.canSpawn = false;
        StartCoroutine(SpawnTrashCor());
    }
    IEnumerator SpawnTrashCor()
    {
        
        while(GameManager.Instance.canSpawn)
        {
            Debug.Log("Spawn");
            SpawnObject();
            yield return new WaitForSeconds(spawnDelay);
        }
    }
    public void SpawnObject()
    {
        GameObject obj = Instantiate(_trashObject,trashSpawner);
        obj.transform.position = new Vector3(playerTransform.position.x,playerTransform.position.y + Random.Range(5f,7f));
    }


}
