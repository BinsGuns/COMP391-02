using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;


public class EnemyHealthSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject _healthBar;
    private float _health;
    private EnemyController _enemyController;
    private PlayerController _playerController;
    private BossController _bossController;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        
        // for normal enemy
        if (GetComponent<EnemyController>())
        {
            _enemyController = GetComponent<EnemyController>();
            _enemyController.OnDamageTaken += OnDamageTaken;
        }

        if (GetComponent<BossController>())
        {
            _bossController = GetComponent<BossController>();
            _bossController.OnDamageTaken += OnDamageTaken;
        }
        
        _health = _healthBar.GetComponent<Slider>().maxValue;
        
        
    }

    private void OnDamageTaken(float damage)
    {
        if(_enemyController) _enemyController.EnemyHurtAnimation?.Invoke();
        
        _health -= damage;
        _healthBar.GetComponent<Slider>().value = _health;
    }

    // Update is called once per frame
    void Update()
    {
        if (_health <= 0)
        {
            if (_enemyController)
            {
                // kill the enemy
                Destroy(_enemyController.transform.parent.gameObject);
                _enemyController.OnEnemyKilled?.Invoke();
            }

            if (_bossController)
            {
                Destroy(_bossController.transform.parent.gameObject);
                _playerController.GameWin?.Invoke();
            }
            //EnemySpawner.Instance._killedEnemyCount++;
        }
    }
}
