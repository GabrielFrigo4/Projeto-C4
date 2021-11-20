using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAnimationLogo : MonoBehaviour
{
    [SerializeField] Texture2D logo;
    private IEnumerator coroutine;
    private SpriteRenderer spriteRender;
    const int SIZE = 116;

    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        coroutine = AnimationPlay(0.095f);
        StartCoroutine(coroutine);
    }

    IEnumerator AnimationPlay(float timeSecondFrame)
    {
        for (int i = 0; i < 81; i++)
        {
            spriteRender.sprite = Sprite.Create(logo, new Rect(SIZE * i, 0, SIZE, SIZE), new Vector2(0.5f, 0.5f), 7, 1);
            yield return new WaitForSeconds(timeSecondFrame);
        }
        SceneScript.GoScene("Menu");
    }
}
