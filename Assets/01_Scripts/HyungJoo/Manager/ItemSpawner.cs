using System.Collections;
using UnityEngine;
using System.Collections.Generic;
public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _shieldItem;
    public Transform itemSpawner;
    public Transform playerTransform;
    public float spawnDelay;
    [SerializeField]
    private MapDataSO _mapDataSO;



    void Awake()
    {
        itemSpawner = this.transform;
        GameManager.canSpawn = false;
        StartCoroutine(SpawnTrashCor());
    }
    IEnumerator SpawnTrashCor()
    {
        while(true)
        {
            if(GameManager.canSpawn)
            {
                Debug.Log("Spawn");
                SpawnObject();
                yield return new WaitForSeconds(spawnDelay);
            }
            yield return null;
        }
    }
    public void SpawnObject()
    {
        if(playerTransform == null)
        {
            playerTransform = FindObjectOfType<PlayerController>().transform;
        }
        GameObject obj = Instantiate(_shieldItem,itemSpawner);
        obj.transform.position = new Vector3(Random.Range(_mapDataSO.minX,_mapDataSO.maxX)
            ,playerTransform.position.y + Random.Range(10f,13f));
    }
}
