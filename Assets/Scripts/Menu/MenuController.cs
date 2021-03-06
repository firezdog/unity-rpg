﻿using UnityEngine;
using UnityRPG;

public class MenuController : MonoBehaviour
{

	[SerializeField] GameObject menu;
	[SerializeField] GameObject defaultPanel;
	GameObject currentPanel;
	GameManager gm;

	// Start is called before the first frame update
	void Start()
	{
		gm = GameManager.instance;
		currentPanel = defaultPanel;
	}

	// Update is called once per frame
	void Update()
	{
		ToggleMenu();
	}

	public void ChangeCurrentPanel(GameObject panel) {
		currentPanel.GetComponent<IMenuPanel>().Blur();
		panel.GetComponent<IMenuPanel>().Activate();
		currentPanel = panel;
	}

	private void ToggleMenu()
	{
		bool menuButtonPushed = Input.GetButtonDown("Fire2");
		if (menuButtonPushed)
		{
			if (!menu.activeInHierarchy && !gm.DialogOpen && !gm.FadingBetweenAreas)
			{
				currentPanel.GetComponent<IMenuPanel>().Activate();
				menu.SetActive(true);
				gm.StatMenuOpen = true;
			}
			else
			{
				currentPanel.GetComponent<IMenuPanel>().Blur();
				currentPanel = defaultPanel;
				menu.SetActive(false);
				gm.StatMenuOpen = false;
			}
		}
	}
}
