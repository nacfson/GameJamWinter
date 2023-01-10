using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    private GameObject subWall;
    Background background;
    // Start is called before the first frame update
    void Start()
    {
        subWall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(background.Rwall > Random.Range(3, 10))
        {
            subWall.SetActive(true);
            background.Rwall = 0;
        }
        else if(background.Rwall == 1)
        {
            subWall.SetActive(false);
        }
        
    }
}
