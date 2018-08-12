using UnityEngine;
using UnityEngine.UI;

public class LivesCounter : MonoBehaviour
{
    [SerializeField]
    private int _startingLives = 3;

    [SerializeField]
    private int _maxLives = 9;

    [SerializeField]
    private GameObject[] _lifeSprites;

    [SerializeField]
    private Text _lifeCount;

    public int NumLives
    {
        get { return _numLives; }
    }

    private int _numLives;

    void Start ()
    {
        UpdateLives (_startingLives);
    }

    /// <summary>
    /// Updates the life counter to the set number of lives.
    /// </summary>
    public void UpdateLives(int lives)
    {
        _numLives = Mathf.Clamp (lives, 0, _maxLives);
        bool useNumeric = lives > _lifeSprites.Length;

        if (useNumeric)
        {
            // Disable all life sprites EXCEPT the first.
            for (int i = 1; i < _lifeSprites.Length; i++)
                _lifeSprites [i].SetActive (false);

            _lifeCount.enabled = true;
            _lifeCount.text = "x " + _numLives;
        }
        else
        {
            _lifeCount.enabled = false;

            // Simple counting loop that determines which heart sprites should be visible.
            for (int i = 0; i < _lifeSprites.Length; i++)
            {
                if (i <= _numLives - 1)
                    _lifeSprites [i].SetActive (true);
                else
                    _lifeSprites [i].SetActive (false);
            }
        }
    }
}
