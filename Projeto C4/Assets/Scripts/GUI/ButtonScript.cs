using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Diagnostics;
using System.IO;

public class ButtonScript:MonoBehaviour
{
	[SerializeField] GameObject menu, option;
	[SerializeField] Slider music, sound;
	[SerializeField] Dropdown language;

	public void Start()
	{
		music.value = SliderScript.volumeMusic;
		sound.value = SliderScript.volumeSound;
		language.value = DropDownScript.languageValue;
		
		Application.targetFrameRate = 60;
	}
	
    public void StartGame()
	{
		SceneScript.GoScene("LevelSelect");
	}
	
	public void OptionGame()
	{
		menu.transform.position = new Vector3(-100, 0, 0);
		option.transform.position = new Vector3(0, 0, 0);
	}
	
	public void ReturnMenu()
	{
		menu.transform.position = new Vector3(0, 0, 0);
		option.transform.position = new Vector3(100, 0, 0);
	}

    public void Restart()
    {
		#if UNITY_IOS
		#else
		string path = Path.GetFullPath(".") + "/" + Application.productName + ".exe";
        Process.Start(path);
        Application.Quit();
		#endif
	}

    public void CloseGame()
	{
		Application.Quit();
	}
}
