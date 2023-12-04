using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrderBook : MonoBehaviour
{
    [SerializeField]
    private Queue<int> _orders = new Queue<int>();

    [SerializeField]
    private GameController _gameController;

    [SerializeField]
    private float _moneyAdded;

    [SerializeField]
    private TMP_Text _orderText;

    [SerializeField]
    private string[] _orderPlaced;

    private int _orderIndex = 0;

    public void CreateNewOrder()
    {
        _orders.Enqueue(_gameController.GetRandomRecipe());
        SetOrderText();
    }

    private void SetOrderText()
    {
        if (_orders.Peek() == 21)
        {
            _orderIndex = 0;
        }
        if (_orders.Peek() == 31)
        {
            _orderIndex = 1;
        }
        if (_orders.Peek() == 45)
        {
            _orderIndex = 2;
        }
        _orderText.text = _orderPlaced[_orderIndex];
    }

    public void SellPotion(int _cauldronContents)
    {
        if (_cauldronContents == _orders.Peek())
            {
                _orders.Dequeue();
                _gameController.AddMoney(_moneyAdded);
                CreateNewOrder();
                return;
            }
    }
}