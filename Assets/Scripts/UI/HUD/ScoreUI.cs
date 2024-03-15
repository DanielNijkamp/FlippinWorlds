using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;
    
    private void Start()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateUI(int score)
    {
        if (_scoreText.gameObject.activeSelf)
        {
            _scoreText.text = score.ToString();
        }
    }
}
