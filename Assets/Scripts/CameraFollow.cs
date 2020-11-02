using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;


    [Range(0.01f, 1f)]
    public float SmoothSpeed;

    private Vector3 offset;

    [Tooltip("Enable toLookAt specified target?")]
    public bool LookAt = false;

    private void Start()
    {
        SmoothSpeed = 1f;
        offset = transform.position - Target.position;
    }

    private void LateUpdate()
    {
        Vector3 newPosition = Target.position + offset;

        transform.position = Vector3.Slerp(transform.position, newPosition, SmoothSpeed);

        if (LookAt)
        {
            transform.LookAt(Target);
        }
    }
}
