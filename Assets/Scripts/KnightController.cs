using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class KnightController : MonoBehaviour
{
    Animator _animatorController;
    Rigidbody2D _rigidBody2D;

    [SerializeField]
    [Tooltip("speed of the knight")]
    [Range(0, 50)]
    float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        _animatorController = GetComponent<Animator>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    bool _isAttacking = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && _isAttacking == false)
        {
            _animatorController.SetTrigger("Attack");
            _isAttacking = true;
        }


        //horizontalni pohyb
        float vx = Input.GetAxisRaw("Horizontal");

        if (vx != 0)
        { 
            _animatorController.SetBool("Moving", true);
            _rigidBody2D.velocity = new Vector2(vx * speed, _rigidBody2D.velocity.y);
        }
        else
        {
            _animatorController.SetBool("Moving", false);
            _rigidBody2D.velocity = Vector2.zero; //new Vector2(0, _rigidBody2D.velocity.y);
        }
    }

    public void StopAttacking()
    {
        _isAttacking = false;
    }
}
