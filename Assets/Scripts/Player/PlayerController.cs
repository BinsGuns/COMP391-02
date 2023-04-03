using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public PlayerMovement playerMovement;
    [HideInInspector]
    public CharacterController characterController;
    [HideInInspector]
    public SpriteRenderer spriteRenderer;
    public BoxCollider hitBoxColider;
    // Start is called before the first frame update
    private GameObject _respawn;
    //Events
    public Action<bool> isPlayerAttacking;
    public Action<bool> OnMove;
    public Action<bool> OnJump;
    public Action<GameObject> OnEnemyHit;
    public Action GameWin;
    public Action GameOver;
    private TextMeshProUGUI _statusWinText;

    private void Start()
    {
        _respawn = GameObject.FindWithTag("GameOver");
        _respawn.SetActive(false);

        GameOver += OnGameOver;
        GameWin += OnGameWin;
    }

    private void OnGameWin()
    {
        _respawn.SetActive(true);
        _statusWinText = _respawn.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _statusWinText.SetText("YOU WIN!");
    }

    private void OnGameOver()
    {
        _respawn.SetActive(true);
    }

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerMovement = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        if(hitBoxColider.gameObject.activeSelf)
            Gizmos.DrawCube(hitBoxColider.transform.position,hitBoxColider.GetComponent<BoxCollider>().size);
    }
}
