using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Usugi;

public class GameSceneUI : SingletonMonobehavior<GameSceneUI>
{
    [SerializeField] private Text _scoreText = default;
    [SerializeField] private Text _timerText = default;
    [SerializeField] private Image _sabotagePanel = default;

    public Text ScoreText { get => _scoreText; set => _scoreText = value; }
    public Text TimerText { get => _timerText; set => _timerText = value; }

    public IEnumerator Sabotage(float interval)
    {
        _sabotagePanel.gameObject.SetActive(true);
        yield return new WaitForSeconds(interval);

        _sabotagePanel.gameObject.SetActive(false);
    }
}
