using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Usugi
{
    /// <summary>
    /// �X�R�A���J�E���g����}�l�[�W���N���X
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] int _score = 0;

        /// <summary>
        /// �X�R�A���J�E���g����N���X
        /// </summary>
        /// <param name="point"></param>
        void AddScore(int point)
        {
            _score += point;
        }
    
    }
}
