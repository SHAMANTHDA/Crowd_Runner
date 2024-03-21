using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Animator animator;

    [Header(" Settings ")]
    private bool isTarget;

    public void SetTarget()
    {
        isTarget = true;
    }

    public bool IsTarget()
    {
        return isTarget;
    }

    public Animator GetAnimator()
    {
        return animator;
    }public void SetAnimator(Animator animator)
    {
        this.animator = animator;
    }
}
