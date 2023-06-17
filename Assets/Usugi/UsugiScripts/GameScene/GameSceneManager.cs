using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Usugi
{
    /// <summary>
    /// �X�R�A���J�E���g����}�l�[�W���N���X
    /// </summary>
    public class GameSceneManager : SingletonMonobehavior<GameSceneManager>
    {
        [SerializeField] int _score = 0;
        [SerializeField] float _limiTime = 30;
        [SerializeField] Text _scoreText;
        string _gameSceneName = "";
        string _resultSceneName = "";
        public int Score => _score;

        private void Start()
        {
            _gameSceneName = SceneManager.GetActiveScene().name;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void Update()
        {
            CountTime();

            _scoreText.text = $"{_score}";
        }

        /// <summary>
        /// �X�R�A���J�E���g����N���X
        /// </summary>
        /// <param name="point"></param>
        public void AddScore(int point)
        {
            _score += point;
        }

        /// <summary>
        /// �V�[���̐؂�ւ����ɃQ�[���V�[���Ȃ�X�R�A��0��
        /// </summary>
        /// <param name="loaded"></param>
        /// <param name="mode"></param>
        void OnSceneLoaded(Scene loaded, LoadSceneMode mode)
        {
            if (loaded.name == _gameSceneName) _score = 0;
        }

        /// <summary>
        /// ���Ԃ��J�E���g����
        /// </summary>
        void CountTime()
        {
            _limiTime -= Time.deltaTime;

            if (_limiTime <= 0)
            {
                LoadResultScene();
            }
        }

        /// <summary>
        /// ���U���g�V�[�������[�h����
        /// </summary>
        public void LoadResultScene()
        {
            SceneManager.LoadScene(_resultSceneName);
        }
    }
}
