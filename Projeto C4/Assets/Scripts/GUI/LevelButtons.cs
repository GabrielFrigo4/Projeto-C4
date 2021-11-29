using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtons : MonoBehaviour
{
	public Button[] buttons;
	public static int currentLevel = 0;
	public static bool canGo2Next = false;
	Transform leveltext;

	void Start()
    {
		buttons = GetComponentsInChildren<Button>();
		leveltext = transform.GetChild(0);
		RefreshButtons();
	}

	void RefreshButtons()
	{
		for (int i = 0; i < buttons.Length; i++)
		{
			if (i > currentLevel)
			{
				buttons[i].interactable = false;
				transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(false);
			}
			else if (i == currentLevel)
			{
				buttons[i].interactable = true;
				transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(true);
			}
			else if (i < currentLevel)
			{
				buttons[i].interactable = true;
				
			}
		}
	}

}