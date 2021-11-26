using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimation : MonoBehaviour
{
	SpriteRenderer spriteRenderer;
	IEnumerator corroutine;
	[HideInInspector] public bool active = false;
	
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
