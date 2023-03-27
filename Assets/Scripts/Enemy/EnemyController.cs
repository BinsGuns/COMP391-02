using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _characterRender;
    [SerializeField] private TextMeshProUGUI _labelText;
    
    private GameObject _player;
    // private EnemyHealthSystem enemyHealthSystem;
    private NavMeshAgent _navMeshAgent;
    public Action<float> OnAttackPlayer;
    public Action OnEnemyKilled;
    

    public Action<float> OnDamageTaken;
    // Start is called before the first frame update
    void Start()
    {
        // enemyHealthSystem = GetComponent<EnemyHealthSystem>();
        _player = GameObject.FindWithTag("Player");
        _navMeshAgent = GetComponent<NavMeshAgent>();
        
        OnAttackPlayer += UpdateLabel;
        
    }

    // Update is called once per frame
    void Update()
    {
        _navMeshAgent.SetDestination(_player.transform.position);

        if (_player.transform.position.x < transform.position.x) _characterRender.flipX = true;
        else _characterRender.flipX = false;

    }

    // TEMPORARY ONLY
    private void UpdateLabel(float damage)
    {
        _labelText.text = "ATTACK";
        StartCoroutine(DisableText());
    }

    private IEnumerator DisableText()
    {
        yield return new WaitForSeconds(0.5f);
        _labelText.text = "";
    }
}
