using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private float _currentMoney;

    [SerializeField]
    private float _maxMoney;

    public bool _isInProgress;

    private float _timer;

    [SerializeField]
    private TMP_Text _timerText;

    [SerializeField]
    private TMP_Text _moneyText;

    public int _cauldronContents = 0;

    [SerializeField]
    private RecipeBook _recipeBook;

    [SerializeField]
    private OrderBook _orderBook;

    private void Start()
    {
        _orderBook.CreateNewOrder();
        _isInProgress = true;
        _timer = 0;
    }

    public void AddIngredient(int _ingredientAdded)
    {
        _cauldronContents = _ingredientAdded + _cauldronContents * 10;
    }

    public void AddPotion()
    {
        Debug.Log("Potion put in drop point.");
    }

    public void PlaceNewOrder()
    {
        _orderBook.CreateNewOrder();
    }

    public void MakePotion()
    {
        _recipeBook.MakePotion(_cauldronContents);
    }

    public void EmptyCaudron()
    {
        _cauldronContents = 0;
    }

    public void AddMoney(float _moneyAdded)
    {
        _currentMoney = _currentMoney + _moneyAdded;
    }

    public int GetRandomRecipe()
    {
        return _recipeBook.RandomRecipe();
    }

    public void CheckSellPotion()
    {
        _orderBook.SellPotion(_cauldronContents);
    }

    void Update()
    {
        if (!_isInProgress)
        {
            _timer = 0;
            return;
        }
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _timerText.text = "00.00";
        }
        else
        {
            _timerText.text = _timer.ToString("00.00");
        }
    }
}
