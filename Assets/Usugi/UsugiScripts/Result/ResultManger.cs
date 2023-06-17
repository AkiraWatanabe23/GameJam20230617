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
        [SerializeField] Text _myScoreText;
        [SerializeField] List<Text> _scoreTexts;
        [SerializeField] Button _toTitleSceneButton;
        [SerializeField] Button _toGameSceneButton;
        [SerializeField] string _startSceneName;
        [SerializeField] string _gameSceneName;

        private void Start()
        {
            _toTitleSceneButton.onClick.AddListener(() => SceneManager.LoadScene(_startSceneName));
            _toGameSceneButton.onClick.AddListener(() => SceneManager.LoadScene(_gameSceneName));
            ShowScore();
            LoadScore();
        }

        void ShowScore()
        {
            _myScoreText.text = $"SCORE:{GameSceneManager.Instance.Score}";
        }

        void LoadScore()
        {
            for (int i = 0; i < 3; i++)
            {
                var score = PlayerPrefs.GetInt($"Score{i}", 0);
                _scoreTexts[i].text = $"SCORE:{score}";
            }
        }

        void SetScore()
        {
            for (int i = 0; i < 3; i++)
            {
                PlayerPrefs.SetInt($"Score{i}", i);
            }
        }
    }
}
