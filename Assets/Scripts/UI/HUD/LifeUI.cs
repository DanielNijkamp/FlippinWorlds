using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LifeUI : MonoBehaviour
{
    private TextMeshProUGUI _lifeText;
    
    private void Start()
    {
        _lifeText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateUI(int lifeCount)
    {
        _lifeText.text = $"{lifeCount.ToString()}X";
    }
}
