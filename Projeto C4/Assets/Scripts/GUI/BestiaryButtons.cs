using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestiaryButtons : MonoBehaviour
{
	[SerializeField] Text textbox, title;
	[TextArea(3,10)]
	public string port, ing;
	public string titletextp, titletexti;
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
