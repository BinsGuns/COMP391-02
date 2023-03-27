using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;


public class EnemyHealthSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject _healthBar;
    private float _health;
    private EnemyController _enemyController;
    // Start is called before the first frame update
    void Start()
    {
        _enemyController = GetComponent<EnemyController>();
        _enemyController.OnDamageTaken += OnDamageTaken;
        _health = _healthBar.GetComponent<Slider>().maxValue;
    }

    private void OnDamageTaken(float damage)
    {
        _health -= damage;
        _healthBar.GetComponent<Slider>().value = _health;
    }

    // Update is called once per frame
    void Update()
    {
        if (_health <= 0)
        { 
            // kill the enemy
            Destroy(_enemyController.transform.parent.gameObject);
            _enemyController.OnEnemyKilled?.Invoke();
            //EnemySpawner.Instance._killedEnemyCount++;
        }
    }
}
