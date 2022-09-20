using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoggoAnimationHandler : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void SetJumping(bool state)
    {
        animator.SetBool("isJumping", state);
    }
}
