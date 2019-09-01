using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject menu;
    PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = PlayerController.instance;
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
                menu.SetActive(true);
                pc.setCanMove(false);
            } else {
                menu.SetActive(false);
                pc.setCanMove(true);
            }
        }
    }
}
