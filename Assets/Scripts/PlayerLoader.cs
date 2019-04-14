using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Plan: if the player is does not exist, instantiate. 
// Doesn't this interfere with the behavior set out in Player script?

public class PlayerLoader : MonoBehaviour
{

    // Get reference to player we want to spawn.
    public GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null) {
            Instantiate(player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
