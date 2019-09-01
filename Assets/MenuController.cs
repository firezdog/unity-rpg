using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject menu;
    PlayerController pc = PlayerController.instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        toggleMenu();
    }

    private void toggleMenu()
    {
        /* this isn't good -- because both menu and dialog create a "player
        cannot move" state, it may be better to make that state part of the
        global singleton */
        bool menuButtonPushed = Input.GetButtonDown("Fire2");
        bool menuIsActive = menu.activeInHierarchy;
        if (menuButtonPushed && !menuIsActive) {
            menu.SetActive(true);
            pc.setCanMove(false);
        } else if (menuButtonPushed && menuIsActive) {
            menu.SetActive(false);
            pc.setCanMove(true);
        }
    }
}
