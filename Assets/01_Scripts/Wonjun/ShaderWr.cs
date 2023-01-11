using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderWr : MonoBehaviour
{
    public Color color = Color.white;

    [Range(0, 16)]
    public int oulineSize = 1;
    [SerializeField]
    private float outlinTime = 0;

    private SpriteRenderer spriteRenderer;


    void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        UpdataOuline(true);
    }

    private void OnDisable()
    {
        UpdataOuline(false);
    }

    private void Update()
    {
        outlinTime += Time.deltaTime;
        if (outlinTime >= 0.7f && outlinTime <= 1f)
        {
            UpdataOuline(true);
        }
        else if(outlinTime >= 1f)
        {
            outlinTime = 0 ;
            UpdataOuline(false);
        }
    }

    void UpdataOuline(bool outline)
    {
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        spriteRenderer.GetPropertyBlock(mpb);
        mpb.SetFloat("_Outline", outline ? 1f : 0);
        mpb.SetColor("_OutlineColor", color);
        mpb.SetFloat("_OutlineSize", oulineSize);
        spriteRenderer.SetPropertyBlock(mpb);
    }
}
