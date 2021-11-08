using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonPauseScript : MonoBehaviour
{
	[SerializeField]GameObject menuPause, option;
	[SerializeField]Slider music, sound;
	
	public void Start()
	{
		music.value = SliderScript.volumeMusic;
		sound.value = SliderScript.volumeSound;
	}
	
	public void Update()
	{
		
	}
	
	public void OptionGame()
	{
		menuPause.transform.position = new Vector3(-18,0,0);
		option.transform.position = new Vector3(0,0,0);
	}
	
	public void PauseGame()
	{
		menuPause.transform.position = new Vector3(0,0,0);
		option.transform.position = new Vector3(18,0,0);
	}
	
	public void ReturnGame()
	{
		menuPause.transform.position = new Vector3(-18,0,0);
		option.transform.position = new Vector3(18,0,0);
	}
	
	public void ExitGame()
	{
		SceneScript.GoScene("Menu");
	}
}