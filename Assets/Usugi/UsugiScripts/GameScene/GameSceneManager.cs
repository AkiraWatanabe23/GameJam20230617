using Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Usugi
{
    /// <summary>
    /// スコアをカウントするマネージャクラス
    /// </summary>
    public class GameSceneManager : SingletonMonobehavior<GameSceneManager>
    {
        [SerializeField] int _score = 0;
        [SerializeField] float _limiTime = 30;
        string _gameSceneName = "";
        public int Score
        {
            get => _score;
            private set
            {
                GameSceneUI.Instance.ScoreText.text = value.ToString();
                _score = value;
            }
        }
        public float LimitTime
        {
            get => _limiTime;
            private set
            {
                Debug.Log(value);

                var currentSceneName = SceneManager.GetActiveScene().name;
                if (currentSceneName == "Result") return;

                GameSceneUI.Instance.TimerText.text = value.ToString("F0");
                _limiTime = value;
            }
        }

        private void Start()
        {
            _gameSceneName = SceneManager.GetActiveScene().name;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void Update()
        {
            CountTime();
        }

        /// <summary>
        /// スコアをカウントするクラス
        /// </summary>
        /// <param name="point"></param>
        public void AddScore(int point)
        {
            Score += point;
        }

        /// <summary>
        /// シーンの切り替え時にゲームシーンならスコアを0に
        /// </summary>
        /// <param name="loaded"></param>
        /// <param name="mode"></param>
        void OnSceneLoaded(Scene loaded, LoadSceneMode mode)
        {
            if (loaded.name == _gameSceneName) _score = 0;
        }

        /// <summary>
        /// 時間をカウントする
        /// </summary>
        void CountTime()
        {
            LimitTime -= Time.deltaTime;

            if (_limiTime <= 0)
            {
                LoadResultScene();
            }
        }

        /// <summary>
        /// リザルトシーンをロードする
        /// </summary>
        public void LoadResultScene()
        {
            SceneManager.LoadScene( Consts.Scenes[SceneNames.RESULT_SCENE]);
        }
    }
}
