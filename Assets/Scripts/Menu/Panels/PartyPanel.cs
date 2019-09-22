using System;
using UnityEngine;
using UnityEngine.UI;
using UnityRPG;

public class PartyPanel : MonoBehaviour, IMenuPanel
{

  [SerializeField] GameObject charSubpanel;

  GameManager gm;

  // Start is called before the first frame update
  void Start()
  {
    gm = GameManager.instance;
    // UpdateParty();
  }

  private void GenerateParty()
  {
    StatController[] characters = gm.StatControllers;
    foreach (StatController character in characters)
    {
			if (!character.gameObject.activeInHierarchy) continue;
      GameObject newPanel = Instantiate(charSubpanel);
      newPanel.transform.SetParent(gameObject.transform, false);
    }
  }

  private void DestroyParty()
  {
    foreach (Transform panel in gameObject.transform)
    {
      Destroy(panel.gameObject);
    }
  }

  private void Update()
  {
    // UpdateParty();
  }

  public void Activate()
  {
    gameObject.SetActive(true);
    GenerateParty();
  }

  public void Blur()
  {
    gameObject.SetActive(false);
    DestroyParty();
  }

  /* private void UpdateParty()
	{
		StatController[] characters = gm.StatControllers;
		Transform[] characterFields = GetMenuCharacterFields();
		for (int i = 0; i < characters.Length; i++)
		{
			StatController currentCharacter = characters[i];
			if (currentCharacter.gameObject.activeInHierarchy)
			{
				characterFields[i].gameObject.SetActive(true);
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
				nextLevelSlider.Find("Experience").GetComponent<Text>().text = 
					$"{currentCharacter.relativeExp()}/{currentCharacter.relativeExpForNextLevel()}";
			}
			else
			{
				characterFields[i].gameObject.SetActive(false);
			}
		}
	} 

	private Transform[] GetMenuCharacterFields()
	{
		Transform characters = gameObject.transform.parent.Find("PartyPanel");
		Transform[] characterFields = new Transform[characters.childCount];
		for (int i = 0; i < characters.childCount; i++)
		{
			characterFields[i] = characters.GetChild(i);
		}
		return characterFields;
	} */
}