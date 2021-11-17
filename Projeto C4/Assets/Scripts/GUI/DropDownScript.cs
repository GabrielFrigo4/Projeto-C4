using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownScript : MonoBehaviour
{
	public static int languageValue = 0;
	
    public void SwitchLenguage(int option)
	{
		languageValue = option;
		
		switch(option)
		{
			case 0:
				LanguageBehaviour.language = Language.Portugues;
				break;
			case 1:
				LanguageBehaviour.language = Language.English;
				break;
		}
		
		foreach(var ling in LanguageBehaviour.languageBehaviour)
		{
			if(ling != null)
			{
				ling.SetLanguage();
			}
		}
	}
}
