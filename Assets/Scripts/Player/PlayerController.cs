using System;
using System.Collections;
using System.Collections.Generic;
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
    
    //Events
    public Action<bool> isPlayerAttacking;
    public Action<GameObject> OnEnemyHit;
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
