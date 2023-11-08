using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterBehavior enemy = collision.GetComponent<CharacterBehavior>();
        CharacterBehavior attacker = this.GetComponentInParent<CharacterBehavior>();

        if (attacker != null && enemy != null)
        {
            attacker.Attack(enemy);
        }
    }
}
