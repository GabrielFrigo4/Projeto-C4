using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpgradeMenu : MonoBehaviour
{
	[SerializeField]GameObject menuLevelSelector, menuUpgrades, ChainUpgrades, parallelUpgrades;
	[SerializeField]Text globalMoneyLabel;
	public const int VACCINECOST = 500, ANTIBIOTICSCOST = 350, ANTIVIRALCOST = 350;
	public static readonly int[] upgradeCosts = new int[] {50,75,100};
	Animator animator;
	public Button[] buttons;
	public Button button_parallel;
	public int level = 0;
	public static Upgrades lastUpgrade;
	public static bool vaccine = false;
	
	void Start()
	{
		animator = GetComponent<Animator>();
		buttons = ChainUpgrades.GetComponentsInChildren<Button>();
		button_parallel = parallelUpgrades.GetComponentInChildren<Button>();
		UptadeMoneyLabel();
		level = (int)lastUpgrade;
		RefreshButtons();				
	}
	
	public void OnUpradesSelected() 
	{
		menuLevelSelector.transform.position = new Vector3(32, 0, 0);
		menuUpgrades.transform.position = new Vector3(0, 0, 0);
	}
	
	public void OnLevelChoiceSelected() 
	{
		menuLevelSelector.transform.position = new Vector3(0, 0, 0);
		menuUpgrades.transform.position = new Vector3(32, 1, 0);
	}
	
	public void OnBack2MenuSelected() 
	{
		SceneScript.GoScene("Menu");
	}

	public void OnUpgradePurchased()
	{
		if (GameIA.globalMoney >= upgradeCosts[level])
		{
			GameIA.globalMoney -= upgradeCosts[level];
			level++;
			RefreshButtons();
			UptadeMoneyLabel();
		}

	}
	public void RefreshButtons()
	{
		for(int i = 0; i < buttons.Length; i++)
		{
			if (i > level) {
				buttons[i].interactable = false;
				buttons[i].animator.SetBool("Interactable", false);
				//Debug.Log(i +" not available");
			} else if (i == level) {
				buttons[i].interactable = true;
				buttons[i].animator.SetBool("Interactable", true);
				//Debug.Log(i +" available");
			} else if (i < level) {
				//Debug.Log(i +" purchased true");
				buttons[i].animator.SetBool("Purchased", true);
				buttons[i].animator.SetBool("Interactable", true);
				buttons[i].interactable = false;
				lastUpgrade = (Upgrades)level;
			}
		}
		if (vaccine == true){
			button_parallel.animator.SetBool("Purchased", true);
		}
	}
	
	public void VaccinePurchased()
	{
		if (GameIA.globalMoney >= VACCINECOST) 
		{
			GameIA.globalMoney -= VACCINECOST;
			vaccine = true;
			RefreshButtons();
			UptadeMoneyLabel();
		}
	}

	
	public void UptadeMoneyLabel()
	{
		globalMoneyLabel.text = GameIA.globalMoney.ToString();
	}

	public void OnFaseSelected(int fase) 
	{
		SceneScript.GoScene($"Fase {fase}");
	}

	public void OnTutorialSelected() 
	{
		SceneScript.GoScene("Tutorial");
	}

	public void OnBestiarySelected() 
	{
		SceneScript.GoScene("Bestiary");
	}

	public void OnTowerManualSelected() 
	{
		SceneScript.GoScene("TowerManual");
	}
}

public enum Upgrades : int
{
	Noone,
	Soap,
	Mask,
	Sanitizer,
}
//Para criar outra fileira de upgrades, duplica o ChainUpgrades, e poem os gameObjects dos botões na ordem, pq o GetComponentsInChildren vai de cima para baixo.