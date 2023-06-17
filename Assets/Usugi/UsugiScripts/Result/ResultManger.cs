using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Constants;
 
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
        SceneNames _startSceneName = SceneNames.TITLE_SCENE;
        SceneNames _gameSceneName = SceneNames.GAME_SCENE;
        List<int> _loadedScore = new List<int>();
        int _highScoreCount = 3;

        private void Start()
        {
            _toTitleSceneButton.onClick.AddListener(() => Fade.Instance.StartFadeOut());
            _toGameSceneButton.onClick.AddListener(() => Fade.Instance.StartFadeOut());
            ShowScore();
            SetScore();
            LoadScore();
        }

        void ShowScore()
        {
            _myScoreText.text = $"SCORE:{GameSceneManager.Instance.Score}";
        }

        void LoadScore()
        {
            for (int i = 0; i < _highScoreCount; i++)
            {
                var score = PlayerPrefs.GetInt($"Score{i}", 0);
                _loadedScore.Add(score);

            }

            _loadedScore.Sort((a, b) => b - a);

            for (int i = 0; i < 3; i++)
            {
                _scoreTexts[i].text = $"{_loadedScore[i]}";
            }
        }
        
        void SetScore()
        {
            _loadedScore.Add(GameSceneManager.Instance.Score);
            _loadedScore.Sort((a, b) => b - a);

            for (int i = 0; i < _highScoreCount; i++)
            {
                if (_loadedScore[i] > _loadedScore.Count - 1) return;
                PlayerPrefs.SetInt($"Score{i}", _loadedScore[i]);
            }
        }

        public void SceneLoad()
        {
            SceneManager.LoadScene(Consts.Scenes[_startSceneName]);
        }
    }
}
