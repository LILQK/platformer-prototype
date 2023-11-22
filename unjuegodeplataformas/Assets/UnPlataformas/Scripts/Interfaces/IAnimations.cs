using System;
using System.Collections;

public interface IAnimations
{
    void OnJump();
    IEnumerator OnDeath(Action<bool> animEnded);
    void OnHurt();
    void UpdateAnimState(int state);
    void UpdateAirSpeed(float speed);
    void UpdateGrounded(bool grounded);
}
