using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;


    [Range(0.01f , 1f)]
    public float Smoothspeed;

    private Vector3 offset;

    [Tooltip("Enable toLookAt specified target?")]
    public bool LookAt = false;

    private void Start()
    {
        Smoothspeed = 0.5f;
        offset = transform.position - Target.position;
    }

    private void LateUpdate()
    {
        Vector3 newPosition = Target.position + offset;

        transform.position = Vector3.Slerp(transform.position, newPosition, Smoothspeed);

        if (LookAt)
        {
            transform.LookAt(Target);
        }
    }
}
