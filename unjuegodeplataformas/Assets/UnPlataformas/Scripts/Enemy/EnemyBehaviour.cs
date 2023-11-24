using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed = 3.0f;
    [SerializeField]private bool movingLeft = true;
    public Transform groundDetection;
    public Transform frontDetection;
    public float detectionDistance = 1f;
    public float dropDistance = 1f;
    public LayerMask groundLayer;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime); //Movemos al enemigo en una direccion  siempre

        //Comprobamos si hay bloque delante y debajo
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, dropDistance, groundLayer);
        RaycastHit2D frontInfo = Physics2D.Raycast(frontDetection.position, movingLeft ? Vector2.left : Vector2.right, detectionDistance, groundLayer);

        //Si no hay suelo o hay algo que nos frena cambiamos de direccion
        if (groundInfo.collider == false || frontInfo.collider == true)
        {
            if (movingLeft)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;
            }
        }
    }

    //Gizmo para poder ver los rayos en el editor
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundDetection.position, groundDetection.position + Vector3.down * dropDistance);
        Gizmos.DrawLine(frontDetection.position, frontDetection.position + (movingLeft ? Vector3.left : Vector3.right) * detectionDistance);
    }
}
