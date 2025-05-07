using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target;         // El personaje
    public Vector3 offset = new Vector3(0, 3, -6); // C�mara detr�s y arriba
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        // Calculamos la rotaci�n del personaje y posicionamos la c�mara detr�s
        Vector3 desiredPosition = target.position + target.rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Que mire siempre al jugador
        transform.LookAt(target);
    }
}
