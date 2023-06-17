using UnityEngine;

public class AirPlane : MonoBehaviour
{
    [SerializeField] private Transform _center = default;
    [SerializeField] private float _radius = 1f;

    private float _theta = 0f;

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        float x = _radius * Mathf.Cos(_theta);
        float z = _radius * Mathf.Sin(_theta);

        transform.position = new Vector3(x, 0, z) + _center.position;
        _theta += 3f * (2f * Mathf.PI / 360f);
    }
}
