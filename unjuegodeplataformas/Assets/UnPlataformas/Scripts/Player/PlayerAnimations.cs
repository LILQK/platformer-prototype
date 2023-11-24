using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour, IAnimations
{
    private Animator animator;
    private Dictionary<string, int> animationHashes = new Dictionary<string, int>();

    private void Awake()
    {
        animator = GetComponent<Animator>();

        // Store hashes in the dictionary
        animationHashes.Add("AnimState", Animator.StringToHash("AnimState"));
        animationHashes.Add("Hurt", Animator.StringToHash("Hurt"));
        animationHashes.Add("Death", Animator.StringToHash("Death"));
        animationHashes.Add("AirSpeedY", Animator.StringToHash("AirSpeedY"));
        animationHashes.Add("Grounded", Animator.StringToHash("Grounded"));
        animationHashes.Add("Jump", Animator.StringToHash("Jump"));
        animationHashes.Add("isDead", Animator.StringToHash("isDead"));
    }

    public void OnJump()
    {
        animator.SetTrigger(animationHashes["Jump"]);
    }

    public IEnumerator OnDeath(Action<bool>animEnded)
    {

        animator.SetTrigger(animationHashes["Death"]);
        animator.SetBool(animationHashes["isDead"],true);

        yield return new WaitForSeconds(GetAnimationLength());

        animEnded?.Invoke(true);
        
    }

    public void OnHurt()
    {
        animator.SetTrigger(animationHashes["Hurt"]);
    }

    public void UpdateAnimState(int state)
    {
        animator.SetInteger(animationHashes["AnimState"], state);
    }

    public void UpdateAirSpeed(float speed)
    {
        animator.SetFloat(animationHashes["AirSpeedY"], speed);
    }

    public void UpdateGrounded(bool grounded)
    {
        animator.SetBool(animationHashes["Grounded"], grounded);
    }

    private float GetAnimationLength()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.length;
    }
}