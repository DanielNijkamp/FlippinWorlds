using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class ShopSystem : MonoBehaviour
{
    [Header("dependency scripts")]
    [SerializeField] private CurrencySystem _currencySystem;

    [Header("shop configuration")]
    [SerializeField] private List<Sprite> _itemList = new List<Sprite>();
    [SerializeField] private List<int> _itemPriceList = new List<int>();
    [SerializeField] private UnityEvent _onChangeUI = new UnityEvent();
    
    [SerializeField] private UnityEvent _onBuy = new UnityEvent();
    private int _currentItem = 0;

    public int CurrentItem => _currentItem;
    public IReadOnlyList<Sprite> ItemList => _itemList.AsReadOnly();
    public IReadOnlyList<int> ItemPriceList => _itemPriceList.AsReadOnly();
    

    private void Start()
    {
        _onChangeUI?.Invoke();
    }
    public void BuyItem()
    {
        if (_itemPriceList[_currentItem] >= _currencySystem.Score) return;
        
        _currencySystem.SubtractPoints(_itemPriceList[_currentItem]);

        _onChangeUI?.Invoke();
        _onBuy?.Invoke();
    }
    
    public void NextItem()
    {
        _currentItem++;
        if (_currentItem >= ItemList.Count) _currentItem = 0;   
        _onChangeUI?.Invoke();
    }

    public void PreviousItem()
    {
        _currentItem--;
        if (_currentItem < 0) _currentItem = ItemList.Count -1;
        _onChangeUI?.Invoke();
    }
}
