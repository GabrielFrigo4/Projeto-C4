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
		SceneManager.LoadScene(scene);
	}
	
}
