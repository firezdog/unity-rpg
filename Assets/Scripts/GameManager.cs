using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static GameManager instance;
    private StatController[] statControllers;
    
    private bool statMenuOpen;
    private bool dialogOpen;
    PlayerController pc;

    public bool DialogOpen 
        { get => dialogOpen; set => dialogOpen = value; }
    public bool StatMenuOpen 
        { get => statMenuOpen; set => statMenuOpen = value; }

    // Start is called before the first frame update
    void Awake()
    {
        instance = LoadHelper.setInstance<GameManager>(gameObject, this, instance);
    }

    void Start() 
    {
        pc = PlayerController.instance;
    }

    // Update is called once per frame
    void Update()
    {
        togglePlayerMovement();
    }

    private void togglePlayerMovement()
    {
        bool menuOpen = StatMenuOpen || DialogOpen;
        if (menuOpen) pc.setCanMove(false);
        else pc.setCanMove(true);
    }
}
