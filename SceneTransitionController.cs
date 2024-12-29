using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransitionController : MonoBehaviour
{
    public Image fadeImage; // Referensi ke UI Image untuk efek fade
    public float fadeDuration = 1f; // Durasi fade dalam detik

    private void Start()
    {
        // Pastikan fadeImage dimulai dengan alpha 0 (transparan)
        if (fadeImage != null)
        {
            fadeImage.color = new Color(0, 0, 0, 0);
            fadeImage.gameObject.SetActive(true); // Aktifkan Image jika belum aktif
        }
    }

    public void TriggerFadeOut(string sceneName)
    {
        // Panggil FadeOut dan pindah ke scene berikutnya
        StartCoroutine(FadeOutAndLoadScene(sceneName));
    }

    private IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        float elapsedTime = 0f;
        Color color = fadeImage.color;

        // Animasi fade dari alpha 0 ke 1
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);
            fadeImage.color = new Color(color.r, color.g, color.b, newAlpha);
            yield return null;
        }

        // Pastikan alpha 1 (gelap total) setelah animasi selesai
        fadeImage.color = new Color(color.r, color.g, color.b, 1);

        // Pindah ke scene berikutnya
        SceneManager.LoadScene(sceneName);
    }
}
