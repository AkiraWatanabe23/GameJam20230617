using Cinemachine;
using UnityEngine;

public class CamZoom : MonoBehaviour
{
    [SerializeField] private float _zoomSpeed = 1f;
    [SerializeField] private CinemachineVirtualCamera _camera = default;

    private readonly float _zoomMinBound = 0.1f;
    private readonly float _zoomMaxBound = 179.9f;

    private void Update()
    {
        Zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    private void Zoom(float scroll)
    {
        _camera.m_Lens.FieldOfView += scroll * _zoomSpeed;
        _camera.m_Lens.FieldOfView = Mathf.Clamp(_camera.m_Lens.FieldOfView, _zoomMinBound, _zoomMaxBound);
    }
}
