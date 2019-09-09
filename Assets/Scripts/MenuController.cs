﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (menuButtonPushed) {
            if (!menu.activeInHierarchy) {
				updateMenu();
                menu.SetActive(true);
				gm.StatMenuOpen = true;
            } else {
                menu.SetActive(false);
				gm.StatMenuOpen = false;
            }
        }
    }

	private void updateMenu()
	{
		StatController[] characters = gm.StatControllers;
		Transform[] characterFields = getMenuCharacterFields();
		foreach(Transform characterField in characterFields)
		{
			print(characterField.name);
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
