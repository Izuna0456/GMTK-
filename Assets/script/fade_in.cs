using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fade_in : MonoBehaviour
{
    public float fadeDuration = 1f; // Duration of the fade effect
    public AnimationCurve fadeCurve; // Animation curve for controlling the fade effect

    private Image fadeImage;
    private bool isFading = false;

    private void Start()
    {
        fadeImage = GetComponent<Image>();
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        fadeImage.gameObject.SetActive(true);
        isFading = true;

        float elapsedTime = 0f;
        Color startColor = fadeImage.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (elapsedTime < fadeDuration)
        {
            float normalizedTime = elapsedTime / fadeDuration;
            float alpha = fadeCurve.Evaluate(normalizedTime);

            fadeImage.color = Color.Lerp(startColor, targetColor, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = targetColor;
        isFading = false;
        fadeImage.gameObject.SetActive(false);
    }

    private IEnumerator FadeOut(int sceneIndex)
    {
        fadeImage.gameObject.SetActive(true);
        isFading = true;

        float elapsedTime = 0f;
        Color startColor = fadeImage.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

        while (elapsedTime < fadeDuration)
        {
            float normalizedTime = elapsedTime / fadeDuration;
            float alpha = fadeCurve.Evaluate(normalizedTime);

            fadeImage.color = Color.Lerp(startColor, targetColor, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = targetColor;
        SceneManager.LoadScene(sceneIndex);
    }

    public void StartFadeOut(int sceneIndex)
    {
        if (!isFading)
        {
            StartCoroutine(FadeOut(sceneIndex));
        }
    }
}
