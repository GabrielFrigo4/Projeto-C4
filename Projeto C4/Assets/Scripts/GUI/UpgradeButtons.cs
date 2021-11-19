using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtons : MonoBehaviour
{
	[SerializeField]GameObject ChainUpgrades;
	public Button[] buttons;
	public int level;
	
	void Start()
	{
		level = 0;
		buttons = ChainUpgrades.GetComponentsInChildren<Button>();
	}
	public void OnUpgradePurchased()
	{
		level++;
		for(int i = 0; i < buttons.Length; i++)
		{
			if (i != level) {
				buttons[i].interactable = false;
			} else {
				buttons[i].interactable = true;
			}
		}

	}
}
