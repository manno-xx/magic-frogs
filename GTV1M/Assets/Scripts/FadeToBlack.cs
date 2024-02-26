using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Fades an UI Image to full 'opaqueness'
/// </summary>
public class FadeToBlack : MonoBehaviour
{
    [SerializeField] private float FadeDuration = 2;

    private Image fadeImage;
    
    /// <summary>
    /// Init the component
    /// </summary>
    void Start()
    {
        fadeImage = GetComponent<Image>();
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Initialize the fade
    /// - activates the game object (is inactive by default to not clutter the screen)
    /// - starts a coroutine (see below)
    /// </summary>
    public void StartFade()
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeOut());
    }
    
    /// <summary>
    /// Fade in a screen filling UI Image
    /// This is a so-called coroutine (https://docs.unity3d.com/Manual/Coroutines.html). A function that can be paused for a set amount of time
    /// This changes the alpha value of the color of the image and then pauses untill the next frame
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeOut()
    {   
        float alpha = 0;
        float fadePerSecond = 1 / FadeDuration;
        Color color = fadeImage.color;
        
        while (alpha <= 1)
        {
            alpha += fadePerSecond * Time.deltaTime;
            color.a = alpha;
            fadeImage.color = color;
            yield return null;
        }
    }
}
