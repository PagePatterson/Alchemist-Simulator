using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Ingredients : MonoBehaviour
{
    [SerializeField]
    private GameObject _particles;

    [SerializeField]
    private int _ingredientAdded;

    [SerializeField]
    private GameController _gameController;

    [SerializeField]
    private GameObject _ingredientPrefab;

    public void Initialize(GameController gameController)
    {
        _gameController = gameController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Cauldron"))
        {
            _gameController.AddIngredient(_ingredientAdded);
            Instantiate(_particles, transform.position, Random.rotation);
            ResetIngredient();
        }

        if (collision.collider.CompareTag("DropPoint"))
        {
            ResetIngredient();
        }
    }

    private void ResetIngredient()
    {
        Destroy(gameObject);
        Instantiate(_ingredientPrefab);
    }
}
