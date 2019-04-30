using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{

    public Image fadeImage;
    private bool fadeOn = false;

    public void turnFadeOn() {
        fadeOn = true;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        fadeImage.enabled = fadeOn;        
    }
}
