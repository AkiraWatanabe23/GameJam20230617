using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Usugi
{
    /// <summary>
    /// スコアをカウントするマネージャクラス
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] int _score = 0;

        /// <summary>
        /// スコアをカウントするクラス
        /// </summary>
        /// <param name="point"></param>
        void AddScore(int point)
        {
            _score += point;
        }
    
    }
}
