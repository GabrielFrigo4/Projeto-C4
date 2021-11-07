using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownScript : MonoBehaviour
{
    public void SwitchLenguage(int option)
	{
		switch(option)
		{
			case 0:
				LanguageBehaviour.lingua = Lingua.Portugues;
				break;
			case 1:
				LanguageBehaviour.lingua = Lingua.Ingles;
				break;
		}
		
		foreach(var ling in LanguageBehaviour.languageBehaviour)
		{
			if(ling != null)
			{
				ling.SetLenguage();
			}
		}
	}
}
