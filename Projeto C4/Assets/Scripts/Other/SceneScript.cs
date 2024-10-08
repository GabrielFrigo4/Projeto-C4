using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public static class SceneScript
{
	public static string lastScene = "Menu";

    public static void GoScene(string scene)
	{
		lastScene = SceneManager.GetActiveScene().name;
		LanguageBehaviour.languageBehaviour.Clear();
		Time.timeScale = 1f;
		SceneManager.LoadScene(scene);
	}
	
	public static void Restart()
	{
		GoScene(SceneManager.GetActiveScene().name);
	}
}
