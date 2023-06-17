using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Constants;

namespace Usugi
{
    /// <summary>
    /// タイトルマネージャ
    /// </summary>
    public class TitleManager : MonoBehaviour
    {
        [SerializeField] SceneNames _loadSceneName;
        [SerializeField] Button _button;

        private void Start()
        {
            _button.onClick.AddListener(() => SceneManager.LoadScene(Consts.Scenes[_loadSceneName]));
        }
    }
}
