using UnityEngine;
using Usugi;

public class AirPlane : MonoBehaviour
{
    [Tooltip("飛行機が円運動を行う中心座標")]
    [SerializeField] private Transform _center = default;
    [Tooltip("円運動の半径")]
    [SerializeField] private float _radius = 1f;
    [Tooltip("連射間隔")]
    [SerializeField] private float _interval = 1f;

    [SerializeField] private int _attackValue = 1;

    private float _timer = 0f;
    private float _theta = 0f;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Attack();
        }
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

    private void Attack()
    {
        if (_timer <= 0.0f)
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(GetCenterPoint()), out RaycastHit hit))
            {
                if (hit.collider.gameObject.TryGetComponent(out Target target))
                {
                    target.Hit(_attackValue);
                }
            }
            _timer = _interval;
        }

        // タイマーの値を減らす
        if (_timer > 0.0f)
        {
            _timer -= Time.deltaTime;
        }
    }

    /// <summary> カメラビューポートの中心座標を取得 </summary>
    private Vector3 GetCenterPoint()
    {
        var viewportCenter = new Vector3(0.5f, 0.5f, Camera.main.nearClipPlane);
        var worldCenter = Camera.main.ViewportToWorldPoint(viewportCenter);
        Debug.Log(worldCenter);

        return worldCenter;
    }
}
