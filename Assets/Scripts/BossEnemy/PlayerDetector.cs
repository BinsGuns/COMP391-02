using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private BossController _bossController;
    // Start is called before the first frame update
    void Start()
    {
        _bossController = gameObject.transform.parent.GetComponent<BossController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _bossController.PlayerOnRadius?.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _bossController.PlayerOnRadius?.Invoke(false);
        }
    }
}
