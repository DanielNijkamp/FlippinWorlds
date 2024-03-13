using UnityEngine;
public class CurrencySystem : ScoreSystem
{
     [SerializeField] private float convertionMultiplier;

    public void ConvertToCurrency(int value)
    {
        int convertedCurrency = (int)(value * convertionMultiplier);
    }
    public override void AddPoints(string value)
    {
        int intValue = int.Parse(value);
        _score += intValue;
        _onValueChanged?.Invoke(intValue);
    }

    public void SubtractPoints(int value)
    {
        _score -= value;
        _onValueChanged?.Invoke(_score);
    }
}
