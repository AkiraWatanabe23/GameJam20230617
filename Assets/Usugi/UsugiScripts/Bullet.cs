using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Usugi
{
    /// <summary>
    /// �e�̃N���X
    /// </summary>
    public class Bullet : MonoBehaviour
    {
        [SerializeField] int _damage = 1;

        private void OnTriggerEnter(Collider other)
        {
            other.TryGetComponent(out Target target);

            if (target) target.Hit(_damage);
        }
    }
}