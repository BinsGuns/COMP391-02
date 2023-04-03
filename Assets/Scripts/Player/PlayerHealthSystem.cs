using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    private EnemyController _enemyController;
    private BossController _bossController;
    private GameObject _inGameUI;
    private Slider _playerUIHealth;
    private GameObject _respawn;
    private TextMeshProUGUI _healthText;
    private PlayerController _playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        _inGameUI = GameObject.FindGameObjectWithTag("InGameUI");
        _bossController = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossController>();
        _playerUIHealth = _inGameUI.transform.GetChild(0).GetChild(0).GetComponent<Slider>();
        _healthText  = _inGameUI.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        _bossController.OnPlayerTakenDamage += OnPlayerTakenDamage;
        _playerController = GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_playerUIHealth.value <= 0)
        {
            _playerController.GameOver.Invoke();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _enemyController = collision.gameObject.GetComponent<EnemyController>();
            _enemyController.OnAttackPlayer += OnPlayerTakenDamage;
        }

    }
    
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _enemyController.OnAttackPlayer -= OnPlayerTakenDamage;
        }
    }

    private void OnPlayerTakenDamage(float damageFromEnemy)
    {
        _playerUIHealth.value -= damageFromEnemy;
        _healthText.text = _playerUIHealth.value.ToString();
    }
}
