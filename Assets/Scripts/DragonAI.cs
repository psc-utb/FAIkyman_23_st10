using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class DragonAI : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    float distanceToAttack = 1;

    [SerializeField]
    float speed = 2;

    Animator _animatorController;
    Rigidbody2D _rigidBody2D;

    void Start()
    {
        _animatorController = GetComponent<Animator>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    bool isAttacking = false;
    float direction;
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            float distance = target.position.x - this.transform.position.x;
            //Vector2.Distance()

            direction = Mathf.Sign(distance);

            if (Mathf.Abs(distance) < distanceToAttack && isAttacking == false)
            {
                _animatorController.SetBool("Moving", false);
                _animatorController.SetTrigger("Attack");
                isAttacking = true;

                _rigidBody2D.velocity = new Vector2(0, _rigidBody2D.velocity.y);
            }
            else if (isAttacking == false)
            {
                _animatorController.SetBool("Moving", true);

                _rigidBody2D.velocity = new Vector2(direction * speed, _rigidBody2D.velocity.y);
            }
        }
        else
        {
            _animatorController.SetBool("Moving", false);

            _rigidBody2D.velocity = new Vector2(0, _rigidBody2D.velocity.y);
        }
    }

    void LateUpdate()
    {
        if (transform.localScale.x < 0
            && direction > 0
            ||
            transform.localScale.x > 0
            && direction < 0)
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    public void StopAttacking()
    {
        isAttacking = false;
    }

    public void StartDeadAnimation(GameObject character)
    {
        _animatorController.SetTrigger("Dead");
    }

    public void DestroyDragon()
    {
        Destroy(this.transform.parent.gameObject);
    }
}
