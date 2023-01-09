using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public Transform originTransform;
    void Awake()
    {
        originTransform  = transform;
    }

    public int CheckHeight()
    {
        return (int)(transform.position.y - originTransform.position.y);
    }
}
