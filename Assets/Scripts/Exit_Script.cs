using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit_Script : MonoBehaviour
{

    public string destination;
    public string origin;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            GameObject.Find("Player").GetComponent<PlayerController>().setFrom(origin);
            SceneManager.LoadSceneAsync(destination);
        }
    }

}
