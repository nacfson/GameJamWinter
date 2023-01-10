using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    private GameObject subWall;
    public Background background;
    //public float RanWall = Random.Range(3f, 10f);
    // Start is called before the first frame update
    void Start()
    {
        background = GameObject.Find("ColliderParent (2)").GetComponent<Background>();
        subWall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(background.Rwall > 3)
        {
            subWall.SetActive(true);
            background.Rwall-=3;
            Debug.Log("µÅ");
        }
        else if(background.Rwall <= 1)
        {
            subWall.SetActive(false);
        }
        
    }
}
