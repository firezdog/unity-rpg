using System;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{

    public static UIFade instance;
    public Image fadeImage;
    public float fadeSpeed;

    private bool fadeTo;
    private bool fadeFrom;

    public void fadeIn() { 
        fadeTo = true; 
        // I think this may be overkill, personally
        fadeFrom = false;
    }
    public void fadeOut() { 
        fadeFrom = true; 
        fadeTo = false;
    }

    void Start() 
    {
        // without this, the scene defaults to the last used fade object, which is transparent (no fade from black effect).
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1f);
        instance = LoadHelper.setInstance<UIFade>(gameObject, this, instance);
        // setInstance();
    }

    // private void setInstance()
	// {
	// 	if (instance == null)
	// 	{
	// 		instance = this;
	// 	}
	// 	else { Destroy(gameObject); }
	// 	DontDestroyOnLoad(gameObject);
	// }

    // Start is called before the first frame update
    void Update()
    {
        handleFading();
    }

  private void handleFading()
  {
    if (fadeTo) {
        fadeImage.color = new Color(
            fadeImage.color.r, 
            fadeImage.color.g, 
            fadeImage.color.b, 
            Mathf.MoveTowards(
                fadeImage.color.a, 1f, fadeSpeed * Time.deltaTime
        ));
        if (fadeImage.color.a == 1f) fadeTo = false;
    }
    if (fadeFrom) {
            fadeImage.color = new Color(
            fadeImage.color.r, 
            fadeImage.color.g, 
            fadeImage.color.b, 
            Mathf.MoveTowards(
                fadeImage.color.a, 0f, fadeSpeed * Time.deltaTime
        ));
        if (fadeImage.color.a == 0f) fadeFrom = false;
    }
  }
}
