using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoAnimation : MonoBehaviour
{
	[SerializeField] Texture logo;
	private IEnumerator coroutine;
	private Animation animation;
	
    // Start is called before the first frame update
    void Start()
    {
		animation = GetComponent<Animation>();
        //Sprite.Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	IEnumerator AnimationPlay(float timeSecondFrame)
	{
		while (true)
        {
			//indi maximo é 81
            yield return new WaitForSeconds(timeSecondFrame);
        }
	}
}
