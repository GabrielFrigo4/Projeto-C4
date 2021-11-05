using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript:MonoBehaviour
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
	
	public void CloseGame()
	{
		Application.Quit();
	}
}
