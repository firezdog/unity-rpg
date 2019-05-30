﻿using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    [SerializeField] TextAsset textAsset;

    private bool focussed = false;
    
    public void Focus() {
        focussed = true;
    }

    DialogController dc;
    // Start is called before the first frame update
    void Start()
    {
        dc = DialogController.instance;
    }

    private string[] getDialog() {
        return Regex.Split (textAsset.text, "\n");
    }

    void Update() {
        if (focussed && Input.GetButtonUp("Fire1")) {
            focussed = false;
            StartCoroutine("Activate");
        }
    }

    IEnumerator Activate() {
        yield return new WaitForSeconds(0.1f);
        dc.ToggleActive(getDialog(), this);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") focussed = true;
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Player") focussed = false;
    }

}
