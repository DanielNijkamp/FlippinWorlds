using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopUIHandler : MonoBehaviour
{
    [Header("Scirpts")]
    [SerializeField] private ShopSystem _shopSystem;
    [SerializeField] private CurrencySystem _currencySystem;

    [Header("UI elements")]
    [SerializeField] private TextMeshProUGUI _currencyText;
    [SerializeField] private TextMeshProUGUI _priceButtonText;
    [SerializeField] private Image _itemSprite;

    public void UpdateUI()
    {
         _currencyText.text = _currencySystem.Score.ToString();
         _priceButtonText.text = _shopSystem.ItemPriceList[_shopSystem.CurrentItem].ToString();
        _itemSprite.sprite = _shopSystem.ItemList[_shopSystem.CurrentItem];

    }
}
