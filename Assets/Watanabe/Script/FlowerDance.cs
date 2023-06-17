using UnityEngine;
using Usugi;
using UniRx;
using UniRx.Triggers;

/// <summary> 敵の動き </summary>
public class FlowerDance : MonoBehaviour, IEnemyBehavior
{
    [Tooltip("妨害する秒数")]
    [SerializeField] private float _sabotage = 1f;
    [SerializeField] private Renderer _renderer = default;

    private void Start()
    {
        _renderer.OnBecameVisibleAsObservable().Subscribe(_ => EnemyBehavior());
    }

    public void EnemyBehavior()
    {
        StartCoroutine(GameSceneUI.Instance.Sabotage(_sabotage));
    }
}
