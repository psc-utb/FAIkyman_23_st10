using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneTeleport : MonoBehaviour
{
    [SerializeField]
    Transform StartingPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.position = StartingPoint.position;
    }
}
