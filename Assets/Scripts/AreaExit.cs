using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit_Script : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) {
        SceneManager.LoadSceneAsync("New_Scene");
    }

}
