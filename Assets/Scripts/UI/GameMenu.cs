using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    private GameMenuState _state;

    [SerializeField]
    private GameObject _pauseMenuUI;

    [SerializeField]
    private GameObject _levelCompleteMenuUI;

    [SerializeField]
    private Button _pauseButton;

    [SerializeField]
    private string _mainMenuSceneId = "MainMenu";

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_state == GameMenuState.Active)
                Pause ();
            else if (_state == GameMenuState.Paused)
                Resume ();
        }   
	}

    public void Pause ()
    {
        _pauseMenuUI.SetActive(true);
        _pauseButton.enabled = false;
        Time.timeScale = 0;
        _state = GameMenuState.Paused;
    }

    public void Resume ()
    {
        _pauseMenuUI.SetActive(false);
        _pauseButton.enabled = true;
        Time.timeScale = 1f;
        _state = GameMenuState.Active;
    }

    public void Win ()
    {
        _levelCompleteMenuUI.SetActive (true);
        _pauseMenuUI.SetActive (false);
        Time.timeScale = 0;
        _state = GameMenuState.Won;
    }

    public void Restart ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMain ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_mainMenuSceneId);
    }

    public void NextLevel ()
    {
        //Resume ();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("NextLevel() called but not implemented, calling Restart() instead.");
        Restart ();
    }
}

public enum GameMenuState
{
    Active,
    Paused,
    Won
}
