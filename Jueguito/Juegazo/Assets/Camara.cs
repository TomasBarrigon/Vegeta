using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Aquí asigna el objeto que quieres seguir

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
    }
}