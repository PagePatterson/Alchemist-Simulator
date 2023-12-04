using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField]
    private GameObject _particles;

    [SerializeField]
    private bool _isOrder;

    [SerializeField]
    private GameController _gameController;

    public void Initialize(GameController gameController)
    {
        _gameController = gameController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("DropPoint"))
        {
            _gameController.CheckSellPotion();
            Destroy(gameObject);
        }

        if (collision.collider.CompareTag("Cauldron"))
        {
            Instantiate(_particles, transform.position, Random.rotation);
            Destroy(gameObject);
        }
    }
}
