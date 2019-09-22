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

  private void GenerateParty()
  {
    StatController[] characters = gm.StatControllers;
    foreach (StatController character in characters)
    {
      if (!character.gameObject.activeInHierarchy) continue;
      GameObject newPanel = Instantiate(charSubpanel);
      newPanel.transform.SetParent(gameObject.transform, false);
      newPanel.GetComponent<CharacterSubpanel>().Character = character;
    }
  }

  private void DestroyParty()
  {
    foreach (Transform panel in gameObject.transform)
    {
      Destroy(panel.gameObject);
    }
  }
}