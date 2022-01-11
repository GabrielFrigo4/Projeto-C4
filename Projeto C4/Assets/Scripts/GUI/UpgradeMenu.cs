using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
	[SerializeField]GameObject menuLevelSelector, menuUpgrades, ChainUpgrades, parallelUpgrades;
	[SerializeField]Text globalMoneyLabel;
	public const int VACCINECOST = 500;
	public static readonly int[] upgradeCosts = new int[] {50,75,100};
	Animator animator;
	public Button[] buttons;
	public Button buyButton;
	public Button button_parallel;
	public int level;
	public static Upgrades lastUpgrade = Upgrades.Noone;
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
		menuLevelSelector.transform.position = new Vector3(100, 0, 0);
		menuUpgrades.transform.position = new Vector3(0, 0, 0);
	}
	
	public void OnLevelChoiceSelected() 
	{
		menuLevelSelector.transform.position = new Vector3(0, 0, 0);
		menuUpgrades.transform.position = new Vector3(100, 0, 0);
	}
	
	public void OnBack2MenuSelected() 
	{
		SceneScript.GoScene("Menu");
	}

#if UNITY_STANDALONE
	public void UpgradeClick()
	{
		if (GameIA.globalMoney >= upgradeCosts[level])
		{
			GameIA.globalMoney -= upgradeCosts[level];
			level++;
			RefreshButtons();
			UptadeMoneyLabel();
		}
	}

	public void VaccineClick()
	{
		if (GameIA.globalMoney >= VACCINECOST && !vaccine)
		{
			GameIA.globalMoney -= VACCINECOST;
			vaccine = true;
			RefreshButtons();
			UptadeMoneyLabel();
		}
	}
#elif UNITY_IOS
	Upgrades buyNow;

	public void UpgradeClick()
	{
		if (GameIA.globalMoney >= upgradeCosts[level])
		{
			buyNow = (Upgrades)(level+1);
			buyButton.interactable = true;
		}
	}

	public void VaccineClick()
	{
		if (GameIA.globalMoney >= VACCINECOST && !vaccine)
		{
			buyNow = Upgrades.Vaccine;
			buyButton.interactable = true;
		}
	}

	public void PurchasedClick()
	{
		if(buyNow == Upgrades.Vaccine)
        {
			if (GameIA.globalMoney >= VACCINECOST)
			{
				GameIA.globalMoney -= VACCINECOST;
				vaccine = true;
				RefreshButtons();
				UptadeMoneyLabel();
			}
		}
        else
        {
			if (GameIA.globalMoney >= upgradeCosts[(int)buyNow - 1])
			{
				GameIA.globalMoney -= upgradeCosts[(int)buyNow - 1];
				level++;
				RefreshButtons();
				UptadeMoneyLabel();
			}
		}
		buyButton.interactable = false;
	}
#endif

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

	public void UptadeMoneyLabel()
	{
		globalMoneyLabel.text = GameIA.globalMoney.ToString();
	}

	public void OnFaseSelected(int fase) 
	{
		if (fase == LevelButtons.currentLevel)
        {
			LevelButtons.canGo2Next = true;
        } 
		else
        {
			LevelButtons.canGo2Next = false;
		}
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
	Vaccine,
}

//Para criar outra fileira de upgrades, duplica o ChainUpgrades, e poem os gameObjects dos botões na ordem, pq o GetComponentsInChildren vai de cima para baixo.