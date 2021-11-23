using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestiaryButtons : MonoBehaviour
{
	[SerializeField] Text textbox, title;
	public string port, ing, titletextp, titletexti;
    public void OnButtonClicked()
    {
		
        if (LanguageBehaviour.language == Language.Portugues)
		{
			textbox.text = port;
			title.text = titletextp;
		}
		else
		{
			textbox.text = ing;
			title.text = titletexti;
		}
	}
}
