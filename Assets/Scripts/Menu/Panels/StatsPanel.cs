using UnityEngine.UI;
using UnityEngine;
using UnityRPG;
using System;

public class StatsPanel : MonoBehaviour, IMenuPanel
{
  [SerializeField] GameObject buttonsPanelPrefab;
  [SerializeField] GameObject button;
  [SerializeField] Text charName, hp, mp, strength, defence, weapon, attackBonus, armor, defenceBonus, nextLevel;
  [SerializeField] Image charImage;

  GameManager gm;
  GameObject buttonsPanelInstance;
  StatController currentlyDisplayed;

  public StatController CurrentlyDisplayed { get => currentlyDisplayed; set => currentlyDisplayed = value; }

  void Awake()
  {
    gm = GameManager.instance;
  }

  void Update()
  {
    SetStats();
  }

  private void SetStats()
  {
    charImage.sprite = currentlyDisplayed.PlayerImage;
    charName.text = currentlyDisplayed.PlayerName;
    hp.text = $"{currentlyDisplayed.CurrentHP}/{currentlyDisplayed.MaxHP}";
    mp.text = $"{currentlyDisplayed.CurrentMP}/{currentlyDisplayed.MaxMP}";
    strength.text = $"{currentlyDisplayed.Attack}";
    defence.text = $"{currentlyDisplayed.Defence}";
    weapon.text = $"{currentlyDisplayed.EquippedWeapon}";
    attackBonus.text = $"{currentlyDisplayed.WeaponBonus}";
    armor.text = $"{currentlyDisplayed.EquippedArmor}";
    defenceBonus.text = $"{currentlyDisplayed.ArmorBonus}";
    nextLevel.text = $"{currentlyDisplayed.remainingExpForNextLevel()}";
  }

  public void Activate()
  {
    gameObject.SetActive(true);
    currentlyDisplayed = gm.StatControllers[0];
    GenerateButtons();
  }

  private void GenerateButtons()
  {
    buttonsPanelInstance = Instantiate(buttonsPanelPrefab);
    buttonsPanelInstance.transform.SetParent(gameObject.transform, false);
    StatController[] characters = gm.StatControllers;
    foreach (StatController character in characters)
    {
      if (!character.gameObject.activeInHierarchy) continue;
      GameObject newButton = Instantiate(button);
      newButton.transform.SetParent(buttonsPanelInstance.transform, false);
      StatButton buttonScript = newButton.GetComponent<StatButton>();
      buttonScript.Character = character;
      buttonScript.SP = this;
    }
  }

  public void Blur()
  {
    gameObject.SetActive(false);
    currentlyDisplayed = gm.StatControllers[0];
    Destroy(buttonsPanelInstance);
  }
}
