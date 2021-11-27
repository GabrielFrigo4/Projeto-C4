using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
	[SerializeField]GameObject Pause;
	List<Transform> ListaTutorial = new List<Transform>();
	int tutorialStep = 0;
	void Awake()
	{
		foreach (Transform child in transform)
		{
			ListaTutorial.Add(child);
		}
	}
	void Start()
	{
		UpdateTutorial();
	}
	void Update()
	{
		if (tutorialStep <= ListaTutorial.Count && Input.GetKeyDown("space"))
		{
			tutorialStep++;
			UpdateTutorial();
		}
	}
	void UpdateTutorial() 
	{
		if (tutorialStep >= ListaTutorial.Count)
		{
			Time.timeScale = 1;
			Pause.SetActive(true);
		} else {
			Time.timeScale = 0;
			Pause.SetActive(false);
		}
		for(int i = 0;i < ListaTutorial.Count; i++) {
			//Debug.Log("i: "+i);
			if (tutorialStep != i) {
				ListaTutorial[i].gameObject.SetActive(false);
			} else {
				ListaTutorial[i].gameObject.SetActive(true);
			}
		}
	}
}
