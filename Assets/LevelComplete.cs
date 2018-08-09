using UnityEngine;

public class LevelComplete : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<LevelCompleteMenu>().Pause();

        
    }
}

