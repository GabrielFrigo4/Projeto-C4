using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAnimation : MonoBehaviour
{
	[SerializeField] Texture2D logo;
    [SerializeField] int size, total, pixelPerUnity;
    [SerializeField] float time;
    private IEnumerator coroutine;
    private SpriteRenderer spriteRender;

    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        coroutine = AnimationPlay(time);
        StartCoroutine(coroutine);
    }
	
	IEnumerator AnimationPlay(float timeSecondFrame)
	{
		for(int i = 0; i < total; i++)
        {
            spriteRender.sprite = Sprite.Create(logo, new Rect(size * i, 0, size, size), new Vector2(0.5f, 0.5f), pixelPerUnity, 1);
            yield return new WaitForSeconds(timeSecondFrame);
        }
        Destroy(gameObject);
	}
}
