using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target;         // El personaje
    public Vector3 offset = new Vector3(0, 3, -6); // Cámara detrás y arriba
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        // Calculamos la rotación del personaje y posicionamos la cámara detrás
        Vector3 desiredPosition = target.position + target.rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Que mire siempre al jugador
        transform.LookAt(target);
    }
}
