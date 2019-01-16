using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance_Script : MonoBehaviour
{
    
    Dictionary<string, Transform> location_map = new Dictionary<string, Transform>();
    [SerializeField] List<string> origins;
    [SerializeField] List<Transform> destinations;

    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach (var origin in origins) {
            location_map.Add(origin, destinations[i]);
            i++;
        }
        var player = GameObject.Find("Player");
        string from = player.GetComponent<PlayerController>().getFrom();
        player.transform.position = location_map[from].position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
