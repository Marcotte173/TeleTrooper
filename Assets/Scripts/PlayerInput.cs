using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    float _moveSpeed;
    [SerializeField]
    float _fallSpeed;
    [SerializeField]
    bool jumping;
    [SerializeField]
    float _jumpSpeed;
    [SerializeField]
    float _jumpHeight;
    [SerializeField]
    float _currentHeight;
    bool _isGrounded;
    Action action;
    Animator anim;
    Arm arm;
    CharacterInfo charInfo;

    private void Start()
    {
        action = GetComponent<Action>();
        anim = GetComponent<Animator>();
        arm = GetComponentInChildren<Arm>();
        charInfo = GetComponent<CharacterInfo>();
    }

    void Update()
    {        
        anim.SetBool("Walking", false);
        if ((charInfo.player1 && Input.GetKey(KeyCode.W))|| (charInfo.player2 && Input.GetKey(KeyCode.UpArrow))) arm.Up();
        else if ((charInfo.player1 && Input.GetKey(KeyCode.S)) || (charInfo.player2 && Input.GetKey(KeyCode.DownArrow))) arm.Down();
        else arm.Standard();
        if ((charInfo.player1 && Input.GetKey(KeyCode.D)) || (charInfo.player2 && Input.GetKey(KeyCode.RightArrow)))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
            action.Forward(_moveSpeed);
            anim.SetBool("Walking", true);
        }
            
        if ((charInfo.player1 && Input.GetKey(KeyCode.A)) || (charInfo.player2 && Input.GetKey(KeyCode.LeftArrow)))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180,transform.eulerAngles.z);
            action.Forward(_moveSpeed);
            anim.SetBool("Walking", true);
        }            
        if (jumping)
        {
            action.Jump(_jumpSpeed);
            _currentHeight += Time.deltaTime;
            if (_currentHeight >= _jumpHeight)
            {
                _currentHeight = 0;
                jumping = false;
            }
        }
        if (_isGrounded == false) action.Fall(_fallSpeed);            
        if (_isGrounded) if ((charInfo.player1 && Input.GetKeyDown(KeyCode.G)) || (charInfo.player2 && Input.GetKeyDown(KeyCode.Keypad1))) jumping = true;
        if ((charInfo.player1 && Input.GetKeyDown(KeyCode.H)) || (charInfo.player2 && Input.GetKeyDown(KeyCode.Keypad2))) action.Shoot();
        if ((charInfo.player1 && Input.GetKeyDown(KeyCode.J)) || (charInfo.player2 && Input.GetKeyDown(KeyCode.Keypad3))) action.Teleport();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _isGrounded = false;
    }
}