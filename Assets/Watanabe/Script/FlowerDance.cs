using System.Collections;
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
        StartCoroutine(Sabotage());
    }

    private IEnumerator Sabotage()
    {
        _sabotagePanel.gameObject.SetActive(true);
        yield return new WaitForSeconds(_sabotage);

        _sabotagePanel.gameObject.SetActive(false);
    }

    private void OnBecameVisible()
    {
        EnemyBehavior();
    }
}
