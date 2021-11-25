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
	void OnMouseOver()
	{
		sprite.enabled = true;
		textbox.enabled = true;
		pricetag.SetActive(true);
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
		pricetag.SetActive(false);
	}
	
}
