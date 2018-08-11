using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour 
{
	public static bool GameIsPaused = false;

    [SerializeField]
	private GameObject _pauseMenuUI;

    [SerializeField]
    private Button _pauseButton;

    [SerializeField]
    private string _mainMenuSceneId = "MainMenu";

	// void Update () 
	// {
	// 	if(Input.GetKeyDown(KeyCode.Escape))
	// 	{
    //         if (GameIsPaused)
    //             Resume ();
    //         else
    //             Pause ();
	// 	}	
	// }

	public void Resume()
	{
		_pauseMenuUI.SetActive(false);
        _pauseButton.enabled = true;
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void Pause()
	{
		_pauseMenuUI.SetActive(true);
        _pauseButton.enabled = false;
		Time.timeScale = 0;
		GameIsPaused = true;
	}

	public void ReturnToMainMenu()
	{
        Resume ();
        SceneManager.LoadScene(_mainMenuSceneId);
	}

	public void RestartLevel()
	{
        Resume ();
		Debug.Log("Restarting: "  + SceneManager.GetActiveScene().name);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
