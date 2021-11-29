using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtons : MonoBehaviour
{
	public Button[] buttons;
	public static int currentLevel = 0;
	public static bool canGo2Next = false;

	void Start()
    {
		buttons = GetComponentsInChildren<Button>();
		RefreshButtons();
	}

	void RefreshButtons()
	{
		for (int i = 0; i < buttons.Length; i++)
		{
			if (i > currentLevel)
			{
				buttons[i].interactable = false;
			}
			else if (i == currentLevel)
			{
				buttons[i].interactable = true;
			
			}
			else if (i < currentLevel)
			{
				buttons[i].interactable = true;
				
			}
		}
	}

}