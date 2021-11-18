using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using static SafePointerMethod;

public class ButtonScript:MonoBehaviour
{
	[SerializeField] GameObject menu, option;
	[SerializeField] Slider music, sound;
	[SerializeField] Dropdown language;

	void Awake()
	{
		QualitySettings.vSyncCount = 1;
		Application.targetFrameRate = 60;
	}

	public void Start()
	{
		music.value = GetPointerValue<float>(SliderScript.volumeMusic);
		sound.value = GetPointerValue<float>(SliderScript.volumeSound);
		language.value = DropDownScript.languageValue;
	}
	
    public void StartGame()
	{
		SceneScript.GoScene("LevelSelect");
	}
	
	public void OptionGame()
	{
		menu.transform.position = new Vector3(-32,0,0);
		option.transform.position = new Vector3(0,0,0);
	}
	
	public void ReturnMenu()
	{
		menu.transform.position = new Vector3(0,0,0);
		option.transform.position = new Vector3(32,0,0);
	}
	
	public void CloseGame()
	{
		Application.Quit();
	}
}
