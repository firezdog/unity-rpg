using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        LoadHelper.setInstance<GameManager>(gameObject, this, instance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
