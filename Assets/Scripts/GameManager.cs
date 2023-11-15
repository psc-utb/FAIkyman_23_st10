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

	// set things up here
	void Awake () {
	}

	// game loop
	void Update() {

		if (Input.GetKeyDown(menuKey)) {
			if (Time.timeScale > 0f)
			{
				SceneManager.LoadScene(mainMenuSceneName, LoadSceneMode.Additive);
				Time.timeScale = 0f;
			} else
			{
				SceneManager.UnloadSceneAsync(mainMenuSceneName);
				Time.timeScale = 1f;
			}
		}
	}

    private void OnDestroy()
    {
		Time.timeScale = 1f;
	}
}
