using UnityEngine;
using Usugi;

public class FlowerCircleMove : MonoBehaviour, IEnemyBehavior
{
    [SerializeField] private Transform _center = default;
    [Tooltip("円運動の半径")]
    [SerializeField] private float _radius = 1f;
    [Range(1f, 5f)]
    [SerializeField] private float _rotateSpeed = 1f;

    private float _theta = 0f;

    private void Update()
    {
        _theta += (2f * Mathf.PI / 360f) * _rotateSpeed;
        EnemyBehavior();
    }

    public void EnemyBehavior()
    {
        float x = _radius * Mathf.Cos(_theta);
        float z = _radius * Mathf.Sin(_theta);

        transform.position = new Vector3(x, 0, z) + _center.position;
    }
}
