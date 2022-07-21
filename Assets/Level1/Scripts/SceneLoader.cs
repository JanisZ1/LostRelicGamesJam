using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader 
{
    private readonly ICoroutineRunner _coroutineRunner;

    public SceneLoader(ICoroutineRunner coroutineRunner) => 
        _coroutineRunner = coroutineRunner;

    public void LoadScene(string sceneName, Action onLoad = null) => 
        _coroutineRunner.StartCoroutine(LoadSceneAsync(sceneName));
    private IEnumerator LoadSceneAsync(string sceneName, Action OnLoad = null)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        yield break;
    }
}