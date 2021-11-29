using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CodeUtils;

public class ScriptAnimation : MonoBehaviour
{
	[SerializeField] Texture2D texture;
    [SerializeField] Vector2 size;
    [SerializeField] int startInd, total, pixelPerUnity;
    [SerializeField] float time;
    [SerializeField] AnimationType animationType;
    [SerializeField] TimeType timeType;
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
	
	public void SetDataAnimation(Texture2D texture, Vector2 size, int startInd, int total, int pixelPerUnity, float time, AnimationType animationType)
	{
		this.texture = texture;
		this.size = size;
		this.startInd = startInd;
		this.total = total;
		this.pixelPerUnity = pixelPerUnity;
		this.time = time;
		this.animationType = animationType;
	}
	
	IEnumerator AnimationPlayNormal(float timeSecondFrame)
    {
        for (int i = startInd; i < total + startInd; i++)
        {
            spriteRender.sprite = Sprite.Create(texture, new Rect(new Vector2(size.x * i, 0), size), new Vector2(0.5f, 0.5f), pixelPerUnity, 1);
            if(timeType == TimeType.NormalTime)
            	yield return new WaitForSeconds(timeSecondFrame);
            else
            	yield return WaitForRealTime(timeSecondFrame);
        }
    }

    IEnumerator AnimationPlayLoop(float timeSecondFrame)
    {
        while (true)
        {
            for (int i = startInd; i < total + startInd; i++)
            {
                spriteRender.sprite = Sprite.Create(texture, new Rect(new Vector2(size.x * i, 0), size), new Vector2(0.5f, 0.5f), pixelPerUnity, 1);
                if(timeType == TimeType.NormalTime)
		        	yield return new WaitForSeconds(timeSecondFrame);
		        else
		        	yield return WaitForRealTime(timeSecondFrame);
            }
        }
    }

    IEnumerator AnimationPlayDestroy(float timeSecondFrame)
	{
		for(int i = startInd; i < total + startInd; i++)
        {
            spriteRender.sprite = Sprite.Create(texture, new Rect(new Vector2(size.x * i, 0), size), new Vector2(0.5f, 0.5f), pixelPerUnity, 1);
            if(timeType == TimeType.NormalTime)
            	yield return new WaitForSeconds(timeSecondFrame);
            else
            	yield return WaitForRealTime(timeSecondFrame);
        }
        Destroy(gameObject);
	}
}

public enum AnimationType
{
    Destroy,
    Loop,
	Normal,
}

public enum TimeType
{
	NormalTime,
	RealTime,
}
