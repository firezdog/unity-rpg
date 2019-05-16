using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using UnityEngine;
using System.Text.RegularExpressions;

public class DialogController : MonoBehaviour
{

    public GameObject dialogBox;
    public GameObject dialogBadge;
    public Text dialogText;
    public Text dialogBadgeText;

    public string[] dialogLines;
    public int currentLine;
    
    public TextAsset textAsset;

    // Start is called before the first frame update
    void Start()
    {
        dialogLines = Regex.Split(textAsset.text, "\n");
        Debug.Log(dialogLines.Length);
        dialogBadgeText.text = dialogLines[0];
        dialogText.text = dialogLines[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
