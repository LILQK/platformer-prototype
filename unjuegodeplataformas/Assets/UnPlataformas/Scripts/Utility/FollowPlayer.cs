using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Pequeño script para hacer que un objeto siga la posicion del jugador en el late update(se actualiza con la camara)
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
