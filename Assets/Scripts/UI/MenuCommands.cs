using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCommands : MonoBehaviour 
{
    [SerializeField]
    private string _sceneId = "Level_01";
    private bool _playClicked;

	void Start ()
    {
        _playClicked = false;
	}

    public void OnClickPlay()
    {
        if (!_playClicked)
        {
            _playClicked = true;
            SceneManager.LoadScene (_sceneId);
        }
    }

    //Add more menu commands as necessary.
}
