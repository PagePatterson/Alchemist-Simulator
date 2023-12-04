using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    private float _timer = 0;

    private void Update()
    {
        _timer = _timer + Time.deltaTime * 1;
        if (_timer > 2)
        {
            Destroy(gameObject);
        }
    }
}
