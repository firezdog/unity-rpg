using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static GameManager instance;
    private StatController[] statControllers;

    // Start is called before the first frame update
    void Awake()
    {
        instance = LoadHelper.setInstance<GameManager>(gameObject, this, instance);
    }

    void Start() 
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
