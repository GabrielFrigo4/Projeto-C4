using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using static PointerMethod;

public class ButtonPauseScript : MonoBehaviour
{
	[SerializeField] GameObject menuPause, gameGUI, option;
	[SerializeField] RuntimeAnimatorController animatorNormal, animatorSpeed;
	[SerializeField] Animator animatorSetVelocity;
	[SerializeField] Slider music, sound;
	[SerializeField] Dropdown language;
	public static bool isPaused = false, isSpeed = false;
	
	public void Start()
	{
		music.value = GetPointerValue<float>(SliderScript.volumeMusic);
		sound.value = GetPointerValue<float>(SliderScript.volumeSound);
		language.value = DropDownScript.languageValue;
		
		animatorSetVelocity.runtimeAnimatorController = animatorNormal;
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
	
	public void SetTimeScale()
	{
		if(Time.timeScale == 1f)
		{
			isSpeed = true;
			animatorSetVelocity.runtimeAnimatorController = animatorSpeed;
			Time.timeScale = 2f;
		}
		else if(Time.timeScale == 2f)
		{
			isSpeed = false;
			animatorSetVelocity.runtimeAnimatorController = animatorNormal;
			Time.timeScale = 1f;
		}
	}
	
	public void PauseGame()
	{
		Time.timeScale = 0;
		isPaused = true;
		menuPause.transform.position = new Vector3(0, 0, 0);
		gameGUI.transform.position = new Vector3(32, 0, 0);
		option.transform.position = new Vector3(64, 0, 0);
	}
	
	public void OptionGame()
	{
		menuPause.transform.position = new Vector3(-64, 0, 0);
		gameGUI.transform.position = new Vector3(-32, 0, 0);
		option.transform.position = new Vector3(0, 0, 0);
	}
	
	public void ReturnGame()
	{
		if(isSpeed)
		{
			Time.timeScale = 2;
		}
		else
		{
			Time.timeScale = 1;
		}
		
		isPaused = false;
		menuPause.transform.position = new Vector3(-32, 0, 0);
		gameGUI.transform.position = new Vector3(0, 0, 0);
		option.transform.position = new Vector3(32, 0, 0);
	}
	
	public void ExitGame()
	{
		Time.timeScale = 1;
		isPaused = false;
		SceneScript.GoScene("LevelSelect");
	}
}