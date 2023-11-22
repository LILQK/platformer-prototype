using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour, IAnimations
{
    private Animator animator;
    private Dictionary<string, int> animationHashes = new Dictionary<string, int>();

    private void Awake()
    {
        animator = GetComponent<Animator>();

        // Store hashes in the dictionary
        animationHashes.Add("RunBool", Animator.StringToHash("Run"));
        animationHashes.Add("Death", Animator.StringToHash("Death"));
    }

    public void OnJump()
    {
        //El enemigo no salta
    }


    public IEnumerator OnDeath(Action<bool> animEnded)
    {

        animator.SetTrigger(animationHashes["Death"]);

        yield return new WaitForSeconds(GetAnimationLength());

        animEnded?.Invoke(true);
    }

    public void OnHurt()
    {
        //No necesita implementacion
    }

    public void UpdateAnimState(int state)
    {
        bool i = state == 0;
        animator.SetBool(animationHashes["RunBool"], i);
    }

    public void UpdateAirSpeed(float speed)
    {
        //No necesita implementacion en el enemigo
    }

    public void UpdateGrounded(bool grounded)
    {
        //No necesita implementacion en el enemigo
    }

    private float GetAnimationLength()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.length;
    }
}
