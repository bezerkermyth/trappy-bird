using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCommands : MonoBehaviour 
{
    [SerializeField]
    private string _sceneId = "SampleScene";
    private bool _playClicked;
    //private GameObject audioSource;

	void Start ()
    {
        _playClicked = false;
	}

    public void OnClickPlay()
    {
        if (!_playClicked)
        {
            //audioSource.SetActive(true);
            _playClicked = true;
            SceneManager.LoadScene(_sceneId);
        }
    }

    //Add more menu commands as necessary.
}
