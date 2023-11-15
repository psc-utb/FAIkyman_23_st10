using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnightDeathSceneManager : MonoBehaviour
{

    [SerializeField]
    float delay = 1;

    public void LoadScene(string sceneName)
    {
        StartCoroutine(nameof(LoadSceneAfterSecond), sceneName);
    }

    private IEnumerator LoadSceneAfterSecond(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName) == false)
        {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(sceneName);
        }
    }
}
