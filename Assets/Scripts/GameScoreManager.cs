using UnityEngine;
using TMPro;

// Tracks and displays the player score
public class GameScoreManager : MonoBehaviour
{
    private int _currentScore = 0;
    private TMP_Text _scoreTextComponent;

    private void Start() 
    {
        _scoreTextComponent = GetComponent<TMP_Text>();
        UpdateScoreDisplay();
    }

    // Adds points to the score
    public void AddScore(int points)
    {
        _currentScore += points;
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        if (_scoreTextComponent != null)
        {
            _scoreTextComponent.text = _currentScore.ToString();
        }
    }
}
