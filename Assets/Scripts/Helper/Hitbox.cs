using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Hitbox : MonoBehaviour
{
    private PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = gameObject.transform.parent.gameObject.GetComponent<PlayerController>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Boss"))
        {
            _playerController.OnEnemyHit?.Invoke(other.gameObject);
        }

       
    }
}
