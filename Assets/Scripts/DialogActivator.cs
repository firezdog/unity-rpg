using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    
    DialogController dc;
    // Start is called before the first frame update
    void Start()
    {
        dc = DialogController.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        dc.ToggleActive(true);
    }

    private void OnCollisionExit2D(Collision2D other) {
        dc.ToggleActive(false);
    }

}
