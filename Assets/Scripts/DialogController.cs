using System;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour {

    [SerializeField] private GameObject dialogBox;
    [SerializeField] private GameObject dialogBadge;
    [SerializeField] private Text dialogText;
    [SerializeField] private Text dialogBadgeText;

    string[] dialogLines;
    int currentLine;
    bool focussed;
    DialogActivator da;

    public static DialogController instance;

    private static Regex nameRegex = new Regex(@"^\[n\]([a-zA-Z]+)");
    private static Regex signRegex = new Regex(@"^\[s\]");

    void Awake() {
        instance = LoadHelper.setInstance<DialogController>(gameObject, this, instance);
    }

    // Start is called before the first frame update
    void Start () {
        this.ToggleActive();
    }

    void printText () {
        // TODO: this closes dialog on arrival at last line -- fix.
        if (currentLine == dialogLines.Length) { 
            close();
            return;
        }
        if (Input.GetButtonUp ("Fire1")) {
            if (focussed) {
                StartCoroutine ("typeText");
            } else {
                StopCoroutine ("typeText");
                focus ();
            }
        }
    }

    IEnumerator typeText () {
        focussed = false;
        checkForDirective();
        for (int i = 0; i < dialogLines[currentLine].Length; i++) {
            yield return new WaitForSeconds (0.1f);
            dialogText.text = dialogLines[currentLine].Substring (0, i);
        }
        focus ();
    }

    void checkForDirective() {
        var match = nameRegex.Match(dialogLines[currentLine]);
        if (match.Success) {
            dialogBadge.SetActive(true);
            dialogBadgeText.text = match.Groups[1].ToString();
            currentLine++;
            return;
        }
        match = signRegex.Match(dialogLines[currentLine]);
        if (match.Success) {
            dialogBadge.SetActive(false);
            currentLine++;
            return;
        }
    }

    void focus () {
        focussed = true;
        dialogText.text = dialogLines[currentLine];
        currentLine++;
    }

    void close () {
        if(Input.GetButtonUp("Fire1")) { 
            StartCoroutine("DelayedToggleActive", 0.1f);
        }

    }

    IEnumerator DelayedToggleActive(float f) {
        yield return new WaitForSeconds(f);
        da.Focus();
        this.ToggleActive();
    }

    public void ToggleActive() {
        dialogBox.SetActive(false);
        clear();
        PlayerController.instance.SetCanMove(true);
    }

    void clear() {
        StopAllCoroutines();
        
        dialogText.text = "";
        dialogBadgeText.text = "";

        dialogLines = null;
        da = null;
        currentLine = 0;
        focussed = false;
    }

    public void ToggleActive(string[] lines, DialogActivator instance) {
        da = instance;
        dialogLines = lines;
        PlayerController.instance.SetCanMove(false);
        dialogBox.SetActive(true);
        StartCoroutine("typeText");
    }

    // Update is called once per frame
    void Update () {
        if (dialogBox.activeInHierarchy) {
            printText ();
        }
    }
}