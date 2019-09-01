using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject menu;

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
        if (Input.GetButtonDown("Fire2")) menu.SetActive(!menu.activeInHierarchy);
    }
}
