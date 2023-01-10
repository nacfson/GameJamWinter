using System.Collections;
using UnityEngine;
using System.Collections.Generic;
public class TrashSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _trashObject;
    public Transform trashSpawner;
    public Transform playerTransform;
    public float spawnDelay;
    [SerializeField]
    private MapDataSO _mapDataSO;
    public List<TrashCollision> trashList = new List<TrashCollision>();



    void Awake()
    {
        trashSpawner = this.transform;
        playerTransform = FindObjectOfType<PlayerController>().transform;
        GameManager.Instance.canSpawn = false;
        StartCoroutine(SpawnTrashCor());
    }
    IEnumerator SpawnTrashCor()
    {
        while(true)
        {

            if(GameManager.Instance.canSpawn)
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
        GameObject obj = Instantiate(RandomObject(),trashSpawner);
        obj.transform.position = new Vector3(Random.Range(_mapDataSO.minX,_mapDataSO.maxX)
            ,playerTransform.position.y + Random.Range(7f,9f));
    }
    public GameObject RandomObject()
    {
        int i = Random.Range(0,trashList.Count);
        return trashList[i].gameObject;
    }

}
