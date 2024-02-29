using UnityEngine;
using TMPro;
public class HighScoreHandler : MonoBehaviour , ScoreSystem
{
    [Header("Text elements")]
    [SerializeField] private TextMeshProUGUI _highscoreText;
    [SerializeField] private TextMeshProUGUI _creditText;

    private int _highscore;
    private int _credits;

    public static HighScoreHandler _highScoreHandler;
    private void Awake()
    {
        _highScoreHandler = this;
    }
    public void OnGameOver(int score)
    {
        if (score >= _highscore)
            _highscore = score;

        _credits += CreditsConversion(score);
        UpdateUI();
    }

    public int CreditsConversion(int score)
    {
        float convertedCredits = score * 0.40f;
        return (int)convertedCredits;
    }
    //DELETE BEFORE MERGING
    public void UpdateUI()
    {
        _highscoreText.text = _highscore.ToString();
        _creditText.text = _credits.ToString();
    }
    #region non implemented methods
    public void OnGameOver() { }
    public void AddPoints(string value) { }
    #endregion
}
