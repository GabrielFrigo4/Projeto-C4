using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestiaryButtons : MonoBehaviour
{
	[SerializeField] Text textbox;
	public string port;
	public string ing;
    public void OnButtonClicked()
    {
        if (LanguageBehaviour.language == Language.Portugues)
		{
			textbox.text = port;
		}
		else
		{
			textbox.text = ing;
		}
	}
}
