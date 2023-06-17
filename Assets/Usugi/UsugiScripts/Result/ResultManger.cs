using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
namespace Usugi
{
    /// <summary>
    /// リザルトマネージャクラス
    /// </summary>
    public class ResultManger : MonoBehaviour
    {
        [SerializeField] Text _scoreText;
        [SerializeField] Button _toTitleSceneButton;
        [SerializeField] Button _toGameSceneButton;
        [SerializeField] string _startSceneName;
        [SerializeField] string _gameSceneName;

        private void Start()
        {
            _toTitleSceneButton.onClick.AddListener(() => SceneManager.LoadScene(_startSceneName));
            _toGameSceneButton.onClick.AddListener(() => SceneManager.LoadScene(_gameSceneName));
            ShowScore();
        }

        void ShowScore()
        {
            _scoreText.text = $"SCORE:{GameSceneManager.Instance.Score}";
        }

    }
}
