using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 1f)]
    private float rotationSpeed;

    void LateUpdate()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
    }
}
