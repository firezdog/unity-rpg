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

    void Awake() {
        // TODO: setInstance should be refactored since it is common to many classes.
        setInstance();
    }

    // Start is called before the first frame update
    void Start () {
        this.ToggleActive();
    }

    private void setInstance() {
		if (instance == null) {
			instance = this;
		}
		else { Destroy(gameObject); }
		DontDestroyOnLoad(gameObject);
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

    void close () {
        if(Input.GetButtonUp("Fire1")) { 
            da.Focus();
            StartCoroutine("DelayedToggleActive", 0.1f);
        }

    }

    IEnumerator DelayedToggleActive(float f) {
        yield return new WaitForSeconds(f);
        this.ToggleActive();
    }

    void focus () {
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

    public void ToggleActive() {
        clear();
        PlayerController.instance.SetCanMove(true);
        dialogBox.SetActive(false);
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

    public void ToggleActive(string id, string[] lines, DialogActivator instance) {
        da = instance;
        dialogBadgeText.text = id;
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