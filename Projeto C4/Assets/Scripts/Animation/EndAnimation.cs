using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimation : MonoBehaviour
{
	SpriteRenderer spriteRenderer;
	IEnumerator corroutine;
	[SerializeField] float time = 0.02f;
	[SerializeField] GameObject[] objs;
	
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0);
    }

    public void StartAnimation()
	{
		corroutine = StartAnimation(time);
		StartCoroutine(corroutine);
	}
	
	IEnumerator StartAnimation(float time)
	{
		while(spriteRenderer.color.a < 1)
		{
			yield return new WaitForRealTime(time);
			spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a + 0.01f);
		}
		foreach(GameObject obj in objs)
		{
			obj.SetActive(true);
		}
	}
}
