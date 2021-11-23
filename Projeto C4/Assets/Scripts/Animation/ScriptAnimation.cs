using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAnimation : MonoBehaviour
{
	[SerializeField] Texture2D texture;
    [SerializeField] Vector2 size;
    [SerializeField] int total, pixelPerUnity;
    [SerializeField] float time;
    [SerializeField] AnimationType animationType;
    private IEnumerator coroutineDestroy, coroutineLoop, coroutineNormal;
    private SpriteRenderer spriteRender;

    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        coroutineDestroy = AnimationPlayDestroy(time);
        coroutineLoop = AnimationPlayLoop(time);
		coroutineNormal = AnimationPlayNormal(time);
        switch (animationType)
        {
            case AnimationType.Destroy:
                StartCoroutine(coroutineDestroy);
                break;
            case AnimationType.Loop:
                StartCoroutine(coroutineLoop);
                break;
			case AnimationType.Normal:
                StartCoroutine(coroutineNormal);
                break;
        }
    }
	
	IEnumerator AnimationPlayNormal(float timeSecondFrame)
    {
        for (int i = 0; i < total; i++)
        {
            spriteRender.sprite = Sprite.Create(texture, new Rect(new Vector2(size.x * i, 0), size), new Vector2(0.5f, 0.5f), pixelPerUnity, 1);
            yield return new WaitForSeconds(timeSecondFrame);
        }
    }

    IEnumerator AnimationPlayLoop(float timeSecondFrame)
    {
        while (true)
        {
            for (int i = 0; i < total; i++)
            {
                spriteRender.sprite = Sprite.Create(texture, new Rect(new Vector2(size.x * i, 0), size), new Vector2(0.5f, 0.5f), pixelPerUnity, 1);
                yield return new WaitForSeconds(timeSecondFrame);
            }
        }
    }

    IEnumerator AnimationPlayDestroy(float timeSecondFrame)
	{
		for(int i = 0; i < total; i++)
        {
            spriteRender.sprite = Sprite.Create(texture, new Rect(new Vector2(size.x * i, 0), size), new Vector2(0.5f, 0.5f), pixelPerUnity, 1);
            yield return new WaitForSeconds(timeSecondFrame);
        }
        Destroy(gameObject);
	}

    public enum AnimationType
    {
        Destroy,
        Loop,
		Normal,
    }
}
