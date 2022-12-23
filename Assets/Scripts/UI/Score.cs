using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private ScoreZone _scoreZone;
    [SerializeField] private TMP_Text _textScore;

    private void OnEnable()
    {
        _scoreZone.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _scoreZone.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _textScore.text = score.ToString();
    }
}