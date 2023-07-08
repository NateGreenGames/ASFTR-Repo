using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] CanvasGroup fadingPanelGroup;
    [SerializeField] Slider slider;
    [SerializeField] GameObject loadingScreenBackground;

    private bool isLoading = false;

    private void Start()
    {
        loadingScreenBackground.SetActive(false);
    }

    public void TransitionScenes(string _scene, float _fadeDuration)
    {
        StartCoroutine(InitializeSceneChange(_scene, _fadeDuration));
    }

    #region LoadingRoutines
    //This coroutines are split because I needed to include to yield return statements to get what I was looking for.
    private IEnumerator InitializeSceneChange(string _scene, float _fadeDuration)
    {
        //If isLoading is equal to false, start loading
        if (isLoading == false)
        {
            yield return StartCoroutine(FadeToBlack(_fadeDuration));
            StartCoroutine(FinalizeSceneChange(_scene, _fadeDuration));
        }
    }
    private IEnumerator FinalizeSceneChange(string _scene, float _fadeDuration)
    {
        yield return StartCoroutine(LoadAsync(_scene));
        StartCoroutine(FadeFromBlack(_fadeDuration));
    }
    private IEnumerator LoadAsync(string _scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(_scene);
        loadingScreenBackground.SetActive(true);
        while (operation.progress < 1)
        {
            slider.value = Mathf.Lerp(0f, 1f, operation.progress);
            yield return new WaitForEndOfFrame();
        }
        loadingScreenBackground.SetActive(false);
    }
    private IEnumerator FadeToBlack(float _duration)
    {
        isLoading = true;
        float elapsedTime = 0;
        while (elapsedTime < _duration)
        {
            fadingPanelGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / _duration);
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
        }
        fadingPanelGroup.alpha = 1f;
    }
    private IEnumerator FadeFromBlack(float _duration)
    {
        float elapsedTime = 0;
        while (elapsedTime < _duration)
        {
            fadingPanelGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / _duration);
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
        }
        fadingPanelGroup.alpha = 0f;
        isLoading = false;
    }
    #endregion
}
