using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
	List<Transform> ListaTutorial = new List<Transform>();
	int tutorialStep = 1;
	void Start()
	{
		foreach (Transform child in transform)
		{
			ListaTutorial.Add(child);
		}
	}
	void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			UpdateTutorial();
			tutorialStep++;
		}
		if (tutorialStep > ListaTutorial.Count)
		{
			Time.timeScale = 1;
		} else {
			Time.timeScale = 0;
		}
	}
	void UpdateTutorial() 
	{
		Debug.Log("tutorialStep: "+tutorialStep+"ListaTutorial.Count: "+ListaTutorial.Count);
		for(int i = 0;i < ListaTutorial.Count; i++) {
			Debug.Log("i: "+i);
			if (tutorialStep != i) {
				ListaTutorial[i].gameObject.SetActive(false);
			} else {
				ListaTutorial[i].gameObject.SetActive(true);
			}
		}
	}
}
