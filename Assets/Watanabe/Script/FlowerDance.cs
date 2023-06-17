using UnityEngine;
using UnityEngine.UI;
using Usugi;

/// <summary> 敵の動き </summary>
public class FlowerDance : MonoBehaviour, IEnemyBehavior
{
    [SerializeField] private Image _sabotagePanel = default;
    [Tooltip("妨害する秒数")]
    [SerializeField] private float _sabotage = 1f;

    public void EnemyBehavior()
    {
        StartCoroutine(GameSceneUI.Instance.Sabotage(_sabotage));
    }

    private void OnBecameVisible()
    {
        EnemyBehavior();
    }
}
