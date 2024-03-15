using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyUI : MonoBehaviour
{
    private TextMeshProUGUI _currencyText;
    
    private void Start()
    {
        _currencyText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateUI(int score)
    {
        if (_currencyText.gameObject.activeSelf)
        {
            _currencyText.text = score.ToString();
        }
    }
}
