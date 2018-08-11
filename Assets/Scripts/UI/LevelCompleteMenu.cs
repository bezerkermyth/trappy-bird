using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompleteMenu : MonoBehaviour 
{
	public static bool GameIsPaused = false;

    [SerializeField]
	private GameObject _levelCompleteMenuUI;

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
		_levelCompleteMenuUI.SetActive(false);
        _pauseButton.enabled = true;
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void Pause()
	{
		_levelCompleteMenuUI.SetActive(true);
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

	//TODO: To put some validation here and/or in ui to check if there is a next level
	public void NextLevel()
	{
		//UNCOMMENT THE TWO LINES BELOW
        //Resume ();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		Debug.Log("NEXT LEVEL CALLED. RESTART LEVELED CALL FOR NOW");
		RestartLevel();
		
	}
}
