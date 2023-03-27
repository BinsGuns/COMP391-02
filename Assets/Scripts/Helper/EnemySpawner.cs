using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class EnemySpawner : MonoBehaviour
{
    //public static EnemySpawner Instance;
    
    [SerializeField] private float _healthSpawner;
    [SerializeField] private int _numberEnemiesToSpawn;
    [SerializeField] private GameObject _prefabEnemy;
    [SerializeField] private Transform _spawningPoint;
    [SerializeField] private GameObject _wall;
    public IObjectPool<GameObject> _poolEnemies;
    private Coroutine _enemyCoroutine;
    private int _currentIndex = 0;
    private int _killedEnemyCount;
    

    void Start()
    {
        _poolEnemies = new ObjectPool<GameObject>(CreatedEnemyPool, 
            OnTakenFromPool, 
            OnReturnedToPool, 
            OnDestroyEnemy, 
            true,
            _numberEnemiesToSpawn,
            _numberEnemiesToSpawn);
        
        
    }
    
    private void OnDestroyEnemy(GameObject obj)
    {
        Destroy(obj);
    }

    private void OnReturnedToPool(GameObject obj)
    {
        obj.SetActive(false);
    }

    private void OnTakenFromPool(GameObject obj)
    {
        obj.SetActive(true);
    }

    private GameObject CreatedEnemyPool()
    {  
        GameObject enemy = Instantiate(_prefabEnemy,_spawningPoint.position , Quaternion.identity,gameObject.transform);
        // 
        return enemy;
    }

    // Update is called once per frame
    void Update()
    {
        if(_killedEnemyCount >= _numberEnemiesToSpawn)
            Destroy(_wall);
    }

    private void EnemyKilled()
    {
        _killedEnemyCount++;
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("Player") && _enemyCoroutine == null)
            _enemyCoroutine = StartCoroutine(SpawnEnemy());
    }
    

    private void OnTriggerExit(Collider other)
    {
        if (_enemyCoroutine != null)
        {
            StopCoroutine(_enemyCoroutine);
            _enemyCoroutine = null;
        }
    }

    private IEnumerator SpawnEnemy()
    {
        
        while (_currentIndex < _numberEnemiesToSpawn)
        {
           GameObject enemy = _poolEnemies.Get();
           enemy.transform.GetChild(0).GetComponent<EnemyController>().OnEnemyKilled += EnemyKilled;
           // enemy.GetComponent<EnemyController>().OnEnemyKilled += EnemyKilled;
            _currentIndex++;
            yield return new WaitForSeconds(3);
        }
        
    }
}
