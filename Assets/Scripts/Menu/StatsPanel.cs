using UnityEngine.UI;
using UnityEngine;
using UnityRPG;
using System;

public class StatsPanel : MonoBehaviour, IMenuPanel
{
	[SerializeField] GameObject buttonsPanelPrefab;
	[SerializeField] GameObject button;
	[SerializeField] Text charName, hp, mp, strength, defence, weapon, attackBonus, armor, defenceBonus, nextLevel;

	GameManager gm;
	GameObject buttonsPanelInstance;
	StatController currentlyDisplayed;

	void Awake()
	{
		gm = GameManager.instance;
	}

	void Update() {
		SetStats();
	}

  	private void SetStats()
  	{
		charName.text = currentlyDisplayed.PlayerName;
		hp.text = $"{currentlyDisplayed.CurrentHP}/{currentlyDisplayed.MaxHP}";
		mp.text = $"{currentlyDisplayed.CurrentMP}/{currentlyDisplayed.MaxMP}";
		strength.text = $"{currentlyDisplayed.Attack}";
		defence.text = $"{currentlyDisplayed.Defence}";
		weapon.text = $"{currentlyDisplayed.EquippedWeapon}";
		attackBonus.text = $"{currentlyDisplayed.WeaponBonus}";
		armor.text = $"{currentlyDisplayed.EquippedArmor}";
		defenceBonus.text = $"{currentlyDisplayed.ArmorBonus}";
		nextLevel.text = $"{currentlyDisplayed.toNextLevel()}";
  	}

  public void Activate()
	{
		gameObject.SetActive(true);
		GenerateButtons();
		currentlyDisplayed = gm.StatControllers[0];
	}

	private void GenerateButtons()
	{
		buttonsPanelInstance = Instantiate(buttonsPanelPrefab);
		buttonsPanelInstance.transform.SetParent(gameObject.transform, false);
		StatController[] characters = gm.StatControllers;
		print(characters);
		foreach (StatController character in characters) 
		{
			GameObject newButton = Instantiate(button);
			newButton.transform.SetParent(buttonsPanelInstance.transform, false);
			newButton.GetComponent<StatButton>().Character = character;
		}
	}

	public void Blur()
	{
		gameObject.SetActive(false);
		Destroy(buttonsPanelInstance);
	}
}
