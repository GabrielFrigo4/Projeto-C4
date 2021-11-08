using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonPauseScript : MonoBehaviour
{
	[SerializeField]GameObject menuPause, gameGUI, option;
	[SerializeField]Slider music, sound;
	public static bool isPaused = false;
	
	public void Start()
	{
		music.value = SliderScript.volumeMusic;
		sound.value = SliderScript.volumeSound;
	}
	
	public void Update()
	{
		bool esc = Input.GetKeyDown(KeyCode.Escape);
		if(esc && !isPaused)
		{
			PauseGame();
		}
		else if(esc && isPaused)
		{
			ReturnGame();
		}
	}
	
	public void PauseGame()
	{
		Time.timeScale = 0;
		isPaused = true;
		menuPause.transform.position = new Vector3(0,0,0);
		gameGUI.transform.position = new Vector3(18,0,0);
		option.transform.position = new Vector3(36,0,0);
	}
	
	public void OptionGame()
	{
		menuPause.transform.position = new Vector3(-36,0,0);
		gameGUI.transform.position = new Vector3(-18,0,0);
		option.transform.position = new Vector3(0,0,0);
	}
	
	public void ReturnGame()
	{
		Time.timeScale = 1;
		isPaused = false;
		menuPause.transform.position = new Vector3(-18,0,0);
		gameGUI.transform.position = new Vector3(0,0,0);
		option.transform.position = new Vector3(18,0,0);
	}
	
	public void ExitGame()
	{
		SceneScript.GoScene("Menu");
	}
}