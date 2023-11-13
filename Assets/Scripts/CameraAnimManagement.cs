using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class CameraAnimManagement : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void MovingCameraAfterDragonDead(GameObject character)
    {
        animator.SetTrigger("DragonDead");
    }
}
