using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMenu:MonoBehaviour{
	[SerializeField]GameObject menu, option;
	
    public void StartGame(){
		
	}
	
	public void OptionGame(){
		menu.transform.position = new Vector3(-18,0,0);
		option.transform.position = new Vector3(0,0,0);
	}
	
	public void ReturnMenu(){
		menu.transform.position = new Vector3(0,0,0);
		option.transform.position = new Vector3(18,0,0);
	}
	
	public void SwitchLanguage(){
		switch(LanguageBehaviour.lingua){
			case Lingua.Portugues:
			LanguageBehaviour.lingua = Lingua.Ingles;
				break;
			case Lingua.Ingles:
			LanguageBehaviour.lingua = Lingua.Portugues;
				break;
		}
		
		foreach(var ling in LanguageBehaviour.languageBehaviour){
			ling.SetLenguage();
		}
	}
	
	public void CloseGame(){
		Application.Quit();
	}
}
