using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{
    [SerializeField]
    private List<int> _recipe = new List<int>();

    [SerializeField]
    private GameController _gameController;

    [SerializeField]
    private List<Potion> _potion = new List<Potion>();

    [SerializeField]
    private Potion _inert;

    private int _randomIndex;

    public void MakePotion(int _cauldronContents)
    {
        if (_cauldronContents == 0) return;
        for (int i = 0; i < _recipe.Count; i++)
        {
            if (_cauldronContents == _recipe[i])
            {
                Debug.Log("correct potion instantiated");
                Instantiate(_potion[i]);
                _gameController.EmptyCaudron();
                return;
            }
            //_recipes.Add(3); add recipe during game
        }
        Debug.Log("incorrect potion instantiated");
        Potion potionCopy = Instantiate(_inert);
        _gameController.EmptyCaudron();
    }

    public int RandomRecipe()
    {
        _randomIndex = Random.Range(0, _recipe.Count);
        return _recipe[_randomIndex];
    }
}