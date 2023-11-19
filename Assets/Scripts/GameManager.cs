using UnityEngine;
using System.Collections;
using UnityEngine.UI; // include UI namespace so can reference UI elements
using UnityEngine.SceneManagement; // include so we can manipulate SceneManager

public class GameManager : MonoBehaviour
{

	[SerializeField]
	KeyCode menuKey = KeyCode.Escape;

	[SerializeField]
	private string mainMenuSceneName;

    AudioListener audioListenerInScene;

    // set things up here
    void Awake ()
    {
        audioListenerInScene = FindObjectOfType<AudioListener>();   //najde audio listener ve scene (mel by existovat jen jeden)
    }

    // game loop
    void Update() {

		if (Input.GetKeyDown(menuKey)) {
			if (Time.timeScale > 0f)
			{
				audioListenerInScene.enabled = false;	//nesmi existovat 2 audio listenery ve scene
                SceneManager.LoadScene(mainMenuSceneName, LoadSceneMode.Additive);
				Time.timeScale = 0f;
			} else
			{
				AsyncOperation asyncOpUnloadScene = SceneManager.UnloadSceneAsync(mainMenuSceneName);
                asyncOpUnloadScene.completed += UnloadScene_completed;	//jedna se o asynchronni metodu, takze musime pockat na dokonceni - v Unity je to mozne pomoci eventu
                Time.timeScale = 1f;
            }
		}
	}

    private void UnloadScene_completed(AsyncOperation obj)
    {
        if (audioListenerInScene != null)
            audioListenerInScene.enabled = true;	//po unloadu sceny se musi audio listener znovu aktivovat
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
        if(audioListenerInScene != null)
            audioListenerInScene.enabled = true;
    }
}
