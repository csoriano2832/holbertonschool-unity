using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Components
    public CharacterController controller;
    public Transform cam;
    public Animator anim;                             
    
    //Character movement and rotation
    public float speed = 6f;
    private float _turnSmoothTime = 0.1f;
    private float _turnSmoothVelocity;
    
    //Jump mechanic
    public float jumpHeight = 2f;
    private Vector3 _playerVelocity;
    private float _gravityValue = -9.81f;
    

    void FixedUpdate()
    {
        Movement();
        Jump();
        FallOff();
    }

    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        if (Input.GetKey("w") | Input.GetKey("a") | Input.GetKey("s") | Input.GetKey("d")) {
            anim.SetBool("isRunning", true);
        }
        else {
            anim.SetBool("isRunning", false);
        }

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

    void Jump()
    {        
        if(controller.isGrounded) {
            _playerVelocity.y = _gravityValue * Time.deltaTime;
        }

        if(Input.GetButton("Jump") && controller.isGrounded) {
            anim.SetTrigger("Jump");
            _playerVelocity.y += Mathf.Sqrt(jumpHeight * -1f * _gravityValue);
        }

        _playerVelocity.y += _gravityValue * Time.deltaTime;
        controller.Move(_playerVelocity * Time.deltaTime);
    }

    void FallOff()
    {
        if (transform.position.y <= -25) {
            transform.position = new Vector3(0, 75, 0);
        }
    }
}
