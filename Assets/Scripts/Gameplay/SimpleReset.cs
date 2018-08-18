using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleReset : MonoBehaviour
{
    [SerializeField]
    private string _sceneId = "Level1";

    [SerializeField]
    private PlayerController _player;

    void Update () 
    {
        if (_player.Dead)
            SceneManager.LoadScene (_sceneId);
	}
}
