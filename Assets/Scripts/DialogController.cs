using System;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour {

    public GameObject dialogBox;
    public GameObject dialogBadge;
    public Text dialogText;
    public Text dialogBadgeText;

    public string[] dialogLines;
    public int currentLine = 1;
    bool focussed = false;

    public TextAsset textAsset;

    // Start is called before the first frame update
    void Start () {
        dialogLines = Regex.Split (textAsset.text, "\n");
        dialogBadgeText.text = dialogLines[currentLine++];
        StartCoroutine ("typeText");
    }

    void printText () {
        if (currentLine == dialogLines.Length) dialogBox.SetActive(false);
        if (Input.GetButtonUp ("Fire1")) {
            if (focussed) {
                StartCoroutine ("typeText");
            } else {
                StopCoroutine ("typeText");
                focus ();
            }
        }
    }

    private void focus () {
        focussed = true;
        dialogText.text = dialogLines[currentLine];
        currentLine++;
    }

    IEnumerator typeText () {
        focussed = false;
        for (int i = 0; i < dialogLines[currentLine].Length; i++) {
            yield return new WaitForSeconds (0.1f);
            dialogText.text = dialogLines[currentLine].Substring (0, i);
        }
        focus ();
    }

    // Update is called once per frame
    void Update () {
        if (dialogBox.activeInHierarchy) {
            printText ();
        }
    }
}