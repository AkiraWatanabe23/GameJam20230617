using UnityEngine;
using System.Collections;
using Usugi;

/// <summary>
/// ˆê’èŠÔ‚¨‚«‚É“_–Å‚·‚é“G‚Ìs“®ˆ—
/// </summary>
public class FlashEnemyMove : MonoBehaviour, IEnemyBehavior
{
    [SerializeField] float _dur = 3;
    Renderer[] _renderer;
    Collider _collider;
    
    public void EnemyBehavior()
    {
        _renderer = GetComponentsInChildren<Renderer>();
        TryGetComponent(out _collider);
        StartCoroutine(nameof(DoFlash));
    }

    IEnumerator DoFlash()
    {
        while(true)
        {
            ChangeVisibility(true);
            yield return new WaitForSeconds(_dur);
            ChangeVisibility(false);
            yield return new WaitForSeconds(_dur);
        }
    }

    private void ChangeVisibility(bool visible)
    {

        if (_renderer.Length == 0) return;
        if (!_collider) return;

        foreach (var rend in _renderer)
        {
            rend.enabled = visible;
        }
        _collider.enabled = visible;
    }
}
