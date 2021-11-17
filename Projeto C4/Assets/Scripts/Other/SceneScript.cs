using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public static class SceneScript
{
    public static void GoScene(string scene)
	{
		LanguageBehaviour.languageBehaviour.Clear();
		SceneManager.LoadScene(scene);
	}
}
