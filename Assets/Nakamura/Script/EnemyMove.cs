using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMove : MonoBehaviour
{
    [Tooltip("移動目標値")]
    [SerializeField] private GameObject _gorl = null;
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private float _dis = 2;
    Vector3 _dirToGorl  = new Vector3 (0, 0, 0);
    Vector3 _startPos;
    Vector3 _gorlPos;
    Rigidbody _rb;
    float dis = 0;
    bool goalToStart = true; 
    void Start()
    {
        if (_gorl != null)
        {
            var objPos =  gameObject.transform.position;
            _startPos = gameObject.transform.position;
            _gorlPos = _gorl.transform.position;
            _dirToGorl = new Vector3(_gorlPos.x - objPos.x, _gorlPos.y - objPos.y, _gorlPos.z - objPos.z);
        }
        else
        {
            Debug.Log("目標地が設定されていません");
        }
        _rb = GetComponent<Rigidbody>();    
    }

    void Update()
    {
        _rb.velocity = _dirToGorl.normalized * _moveSpeed;

        if (goalToStart)
        {
            dis = (_gorlPos.y - gameObject.transform.position.x) * (_gorlPos.x - gameObject.transform.position.x) +
                (_gorlPos.y - gameObject.transform.position.y) * (_gorlPos.y - gameObject.transform.position.y) +
                (_gorlPos.z - gameObject.transform.position.z) * (_gorlPos.z - gameObject.transform.position.z);
        }
        else
        {
            dis = (_startPos.x - gameObject.transform.position.x) * (_startPos.x - gameObject.transform.position.x) +
                (_startPos.y - gameObject.transform.position.y) * (_startPos.y - gameObject.transform.position.y) +
                (_startPos.z - gameObject.transform.position.z) * (_startPos.z - gameObject.transform.position.z);
        }

        if (dis <= _dis * _dis)
        {
            _dirToGorl = new Vector3(_dirToGorl.x * -1, _dirToGorl.y * -1, _dirToGorl.z * -1);
            goalToStart = goalToStart ? false : true;
        }
    }
}
