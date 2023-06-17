using UnityEngine;
using Usugi;
using UnityEngine.UI;

public class AirPlane : MonoBehaviour
{
    [Tooltip("飛行機が円運動を行う中心座標")]
    [SerializeField] Transform _center;
    [SerializeField] private Image _centerImage = default;
    [Tooltip("円運動の半径")]
    [SerializeField] private float _radius = 1f;
    [Tooltip("連射間隔")]
    [SerializeField] private float _interval = 1f;
    [Range(1f, 5f)]
    [SerializeField] private float _rotateSpeed = 1f;

    [SerializeField] private int _attackValue = 1;

    private float _timer = 0f;
    private float _theta = 0f;
    private BulletType _bulletType = BulletType.Normal;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Attack();
        }

        if (Input.GetMouseButton(1))
        {
            _bulletType = _bulletType == BulletType.Normal ?
                          BulletType.Grenade : BulletType.Normal;
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
        _theta += (2f * Mathf.PI / 360f) * _rotateSpeed;
    }

    private void Attack()
    {
        _timer = 0;
        if (_timer <= 0.0f)
        {
            AttackForType(_bulletType);
            _timer = _interval;
        }

        // タイマーの値を減らす
        if (_timer > 0.0f)
        {
            _timer -= Time.deltaTime;
        }
    }

    private void AttackForType(BulletType bulletType)
    {
        if (bulletType == BulletType.Normal)
        {
            Ray ray = Camera.main.ScreenPointToRay(_centerImage.rectTransform.position);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            if  (hits.Length != 0)
            {
                for (int i = 0; i < 1; i++)
                {
                    if (hits[i].collider.gameObject.TryGetComponent(out Target target)) target.Hit(_attackValue);
                }
            }
            //if (Physics.Raycast(Camera.main.ScreenPointToRay(_center.position)))
            //{
            //    RaycastHit[] hits = Physics.RaycastAll(ray);
            //    if (hit.collider.gameObject.TryGetComponent(out Target target)) target.Hit(_attackValue);
            //}
        }
        else
        {
            if (Physics.SphereCast(Camera.main.ScreenPointToRay(GetCenterPoint()), 5f, out RaycastHit hit))
            {
                Debug.Log("あたった");
                if (hit.collider.gameObject.TryGetComponent(out Target target)) target.Hit(_attackValue);
            }
        }
    }

    /// <summary> カメラビューポートの中心座標を取得 </summary>
    private Vector3 GetCenterPoint()
    {
        var viewportCenter = new Vector3(0.5f, 0.5f, 0f);
        var worldCenter = Camera.main.ViewportToWorldPoint(viewportCenter);

        return worldCenter;
    }

    public enum BulletType
    {
        Normal,
        Grenade,
    }
}
