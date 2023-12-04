using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWand : MonoBehaviour
{
    [SerializeField]
    private GameController _gameController;

    public void Initialize(GameController gameController)
    {
        _gameController = gameController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Cauldron"))
        {
            _gameController.MakePotion();
        }
    }
}
