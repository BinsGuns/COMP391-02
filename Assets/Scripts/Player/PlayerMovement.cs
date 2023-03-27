using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;
    [SerializeField] private  float jumpHeight;
    private bool isJumping;
    private float gravityValue = -9.81f;
    private float _hitboxXOffset = 1.40f;
    private PlayerController _playerController;
    private CharacterController _characterController;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform _hitboxCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _characterController = _playerController.characterController;
        _hitboxCollider = _playerController.hitBoxColider.transform;
    }

    // Update is called once per frame
    void Update()
    {

        groundedPlayer = _characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        
        // jump
        if (groundedPlayer && playerVelocity.y > 0)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        
        // add gravity
        playerVelocity.y += gravityValue * Time.deltaTime;
            
        // this moves left and right
        _characterController.Move(playerVelocity * Time.deltaTime * _playerSpeed);
            
        

    }
    
    public void OnPlayerMove(float valueX,float valueY)
    {
        playerVelocity = new Vector3(valueX, valueY, 0); // left and right and jump
        // flip the character image
        if (valueX < 0 )
        {
           // _hitboxCollider.localPosition = Vector3.zero;
            _hitboxCollider.localPosition = new Vector3( -_hitboxXOffset, 0, 0);
            _playerController.spriteRenderer.flipX = true;
        }else if (valueX > 0)
        {
            _hitboxCollider.localPosition = new Vector3( _hitboxXOffset, 0, 0); // position hitbox left
            _playerController.spriteRenderer.flipX = false;
            
        }
    }
    

}
    


