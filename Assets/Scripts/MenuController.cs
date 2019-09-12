using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
  [SerializeField] GameObject menu;
  GameManager gm;

  // Start is called before the first frame update
  void Start()
  {
    gm = GameManager.instance;
  }

  // Update is called once per frame
  void Update()
  {
    toggleMenu();
  }

  private void toggleMenu()
  {
    bool menuButtonPushed = Input.GetButtonDown("Fire2");
    if (menuButtonPushed)
    {
      if (!menu.activeInHierarchy)
      {
        updateMenu();
        menu.SetActive(true);
        gm.StatMenuOpen = true;
      }
      else
      {
        menu.SetActive(false);
        gm.StatMenuOpen = false;
      }
    }
  }

  private void updateMenu()
  {
    StatController[] characters = gm.StatControllers;
    Transform[] characterFields = getMenuCharacterFields();
    for (int i = 0; i < characters.Length; i++)
    {
      StatController currentCharacter = characters[i];
      if (currentCharacter.gameObject.activeInHierarchy) {
        Transform characterColumn = characterFields[i].Find("Character");
        characterColumn.Find("CharacterName").GetComponent<Text>().text = currentCharacter.PlayerName;
        characterColumn.Find("CharacterImage").GetComponent<Image>().sprite = currentCharacter.PlayerImage;
        Transform infoColumn = characterFields[i].Find("Information");
        Transform status = infoColumn.Find("Status");
        status.Find("CharacterHP").GetComponent<Text>().text = $"Health: {currentCharacter.CurrentHP}/{currentCharacter.MaxHP}";
        status.Find("CharacterMP").GetComponent<Text>().text = $"Magic: {currentCharacter.CurrentMP}/{currentCharacter.MaxMP}";
        status.Find("CharacterLevel").GetComponent<Text>().text = $"Level: {currentCharacter.Level}";
        Transform nextLevelSlider = infoColumn.Find("NextLevelSlider");
        nextLevelSlider.GetComponent<Slider>().value = currentCharacter.percentToLevel();
        nextLevelSlider.Find("Experience").GetComponent<Text>().text = $"{currentCharacter.Exp}/{currentCharacter.toNextLevel()}";
      } else {
        characterFields[i].gameObject.SetActive(false);
      }
    }
  }

  private Transform[] getMenuCharacterFields()
  {
    Transform characters = menu.transform.Find("Characters");
    Transform[] characterFields = new Transform[characters.childCount];
    for (int i = 0; i < characters.childCount; i++)
    {
      characterFields[i] = characters.GetChild(i);
    }
    return characterFields;
  }
}
