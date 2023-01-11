using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Warning : MonoBehaviour
{
    public Transform boxTransform;
    [SerializeField]
    private GameObject Box;
    [SerializeField]
    private GameObject warning;
    [SerializeField]
    private float boxTime = 0f;
    public Background background;
    // Start is called before the first frame update
    void Start()
    {
        warning.SetActive(false);   
        background = GameObject.Find("ColliderParent (2)").GetComponent<Background>();
    }

    // Update is called once per frame
    void Update()
    {
        if (background.warningBox > 2)
        {
            warning.SetActive(true);
            boxTime += Time.deltaTime;
            if(boxTime > 2f)
            {
                StartCoroutine(boxspawn());
                background.warningBox = 0;
                StopCoroutine(boxspawn());
                
            }
        }
        else if(background.warningBox < 1)
        {
            warning.SetActive(false);
        }
    }
    IEnumerator boxspawn()
    {
        Instantiate(Box, boxTransform);
        boxTime = 0f;
        yield return new WaitForSeconds(1f);
    }

   
}
