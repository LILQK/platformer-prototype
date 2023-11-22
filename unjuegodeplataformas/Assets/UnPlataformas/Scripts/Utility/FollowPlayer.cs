using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;

    private void Awake()
    {
        player = transform.parent;
        transform.parent = null;
    }

    private void LateUpdate()
    {
        if (player != null) {
            transform.position = new Vector2(player.position.x, transform.position.y);
        }
    }
}
