using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonPauseScript : MonoBehaviour
{
	[SerializeField]GameObject menuPause, option;
	[SerializeField]Slider music, sound;
	bool isPaused = false;
	
	public void Start()
	{
		music.value = SliderScript.volumeMusic;
		sound.value = SliderScript.volumeSound;
	}
	
	public void Update()
	{
		if(Input.GetKeyDown("escape") && !isPaused)
		{
			PauseGame();
		}
	}
	
	public void PauseGame()
	{
		isPaused = true;
		menuPause.transform.position = new Vector3(0,0,0);
		option.transform.position = new Vector3(18,0,0);
	}
	
	public void OptionGame()
	{
		menuPause.transform.position = new Vector3(-18,0,0);
		option.transform.position = new Vector3(0,0,0);
	}
	
	public void ReturnGame()
	{
		isPaused = false;
		menuPause.transform.position = new Vector3(-18,0,0);
		option.transform.position = new Vector3(18,0,0);
	}
	
	public void ExitGame()
	{
		SceneScript.GoScene("Menu");
	}
}