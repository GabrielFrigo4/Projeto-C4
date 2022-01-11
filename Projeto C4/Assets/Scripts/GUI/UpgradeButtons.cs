using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtons : MonoBehaviour
{
	[SerializeField] GameObject dialogbox;
	GameObject pricetag;
	Text textbox, pricetext;
	Image sprite;
	[TextArea(3, 10)]
	public string textdescriptionp, textdescriptioni;

	void Start()
	{
		textbox = dialogbox.GetComponentInChildren<Text>();
		pricetag = gameObject.transform.GetChild(0).gameObject;
		pricetext = pricetag.GetComponentInChildren<Text>();
		sprite = dialogbox.GetComponent<Image>();
		sprite.enabled = false;
		textbox.enabled = false;
	}

#if UNITY_STANDALONE
	void OnMouseOver()
	{
		sprite.enabled = true;
		textbox.enabled = true;
		if (pricetag != null){pricetag.SetActive(true);}
		if (LanguageBehaviour.language == Language.Portugues) 
		{
			textbox.text = textdescriptionp;
		}
		else 
		{
			textbox.text = textdescriptioni;
		}
	}

	void OnMouseExit()
	{
		sprite.enabled = false;
		textbox.enabled = false;
		if (pricetag != null){pricetag.SetActive(false);}
	}
#endif

#if UNITY_IOS
	bool onMouseExit = true;

	void OnMouseOver()
	{
		onMouseExit = false;
	}

	void OnMouseExit()
	{
		onMouseExit = true;
	}

	private void Update()
    {
        if (Input.GetMouseButtonUp(0) && onMouseExit)
        {
			sprite.enabled = false;
			textbox.enabled = false;
			if (pricetag != null) { pricetag.SetActive(false); }
		}
	}

    private void LateUpdate()
    {
		if (Input.GetMouseButtonUp(0) && !onMouseExit)
		{
			sprite.enabled = true;
			textbox.enabled = true;
			if (pricetag != null) { pricetag.SetActive(true); }
			if (LanguageBehaviour.language == Language.Portugues)
			{
				textbox.text = textdescriptionp;
			}
			else
			{
				textbox.text = textdescriptioni;
			}
		}
	}
#endif
}
