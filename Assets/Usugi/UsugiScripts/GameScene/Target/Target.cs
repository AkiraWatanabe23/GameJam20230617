using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Usugi
{
    /// <summary>
    /// ターゲットのクラス
    /// 耐久値を持ち、死ぬとスコアマネージャーにスコアを加算
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
        /// 自身の移動ルーチンを取得し、あるなら実行する
        /// </summary>
        private void InitializeEnemyRoutine()
        {
            TryGetComponent(out _enemyBehavior);
            if (_enemyBehavior != null) _enemyBehavior.EnemyBehavior();
        }

        /// <summary>
        /// 被弾時の処理
        /// </summary>
        /// <param name="damage"></param>
        public void Hit(int damage)
        {
            _hp -= damage;
            if (_hp <= 0) Death();
        }

        /// <summary>
        /// 死亡時の処理
        /// </summary>
        void Death()
        {
            Debug.Log("Death");
            GameSceneManager.Instance.AddScore(_point);
        }
    }

}