using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public Vector2 originTransform;
    void Awake()
    {
        originTransform  = transform.position;
    }
    public int CheckHeight()
    {
        return (int)(transform.position.y - originTransform.y);
    }
}
