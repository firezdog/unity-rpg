using UnityEngine.UI;
using UnityEngine;
using UnityRPG;
using System;

public class StatsPanel : MonoBehaviour, IMenuPanel
{
  [SerializeField] GameObject buttonsPanelPrefab;
	[SerializeField] GameObject button;
  GameManager gm;
	GameObject buttonsPanelInstance;

  void Awake()
  {
    gm = GameManager.instance;
  }

  public void Activate()
  {
    gameObject.SetActive(true);
		GenerateButtons();
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
