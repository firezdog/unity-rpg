using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSubpanel : MonoBehaviour
{

    [SerializeField] Text charName, charHP, charMP, charLevel, charExp;
    [SerializeField] Image charImage;
    [SerializeField] Slider expSlider;

    StatController character;
    public StatController Character { get => character; set => character = value; }

    // Start is called before the first frame update
    void Start()
    {
        UpdateCharacter();
    }

    private void UpdateCharacter()
    {
        charName.text = character.PlayerName;
        charHP.text = $"{character.CurrentHP}/{character.MaxHP}";
        charMP.text = $"{character.CurrentMP}/{character.MaxMP}";
        charLevel.text = $"{character.Level}";
        charExp.text = $"{character.relativeExp()}/{character.relativeExpForNextLevel()}";
        charImage.sprite = character.PlayerImage;
        expSlider.value = character.percentToLevel();
    }

  // Update is called once per frame
  void Update()
    {
        UpdateCharacter();
    }
}
