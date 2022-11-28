using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class replaceSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public GameObject doc;
    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite; 
    }

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        doc.SetActive(false);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ChangeSprite();
            doc.SetActive(true);
        }
    }

}
