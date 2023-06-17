using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Usugi
{
    /// <summary>
    /// �^�[�Q�b�g�̃N���X
    /// �ϋv�l�������A���ʂƃX�R�A�}�l�[�W���[�ɃX�R�A�����Z
    /// </summary>
    public class Target : MonoBehaviour
    {
        [SerializeField] int _hp = 1;
        [SerializeField] int _point = 1;
        IEnemyBehavior _enemyBehavior;

        private void Start()
        {
            InitializeEnemyRoutine();
        }

        /// <summary>
        /// ���g�̈ړ����[�`�����擾���A����Ȃ���s����
        /// </summary>
        private void InitializeEnemyRoutine()
        {
            TryGetComponent(out _enemyBehavior);
            if (_enemyBehavior != null) _enemyBehavior.EnemyBehavior();
        }

        /// <summary>
        /// ��e���̏���
        /// </summary>
        /// <param name="damage"></param>
        public void Hit(int damage)
        {
            _hp -= damage;
            if (_hp <= 0) Death();
        }

        /// <summary>
        /// ���S���̏���
        /// </summary>
        void Death()
        {
            Debug.Log("Death");
            GameSceneManager.Instance.AddScore(_point);
        }
    }

}