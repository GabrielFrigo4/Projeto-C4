using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMenu:MonoBehaviour
{
	[SerializeField]GameObject menu, option;
	
    public void StartGame()
	{
		SceneScript.GoScene("Game");
	}
	
	public void OptionGame()
	{
		menu.transform.position = new Vector3(-18,0,0);
		option.transform.position = new Vector3(0,0,0);
	}
	
	public void ReturnMenu()
	{
		menu.transform.position = new Vector3(0,0,0);
		option.transform.position = new Vector3(18,0,0);
	}
	
	public void SwitchLenguage(int option)
	{
		switch(option)
		{
			case 1:
			LanguageBehaviour.lingua = Lingua.Ingles;
				break;
			case 0:
			LanguageBehaviour.lingua = Lingua.Portugues;
				break;
		}
		
		foreach(var ling in LanguageBehaviour.languageBehaviour)
		{
			if(ling != null)
				ling.SetLenguage();
		}
	}
	
	public void CloseGame()
	{
		Application.Quit();
	}
}
