using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Usugi
{
    /// <summary>
    /// タイトルマネージャ
    /// </summary>
    public class TitleManager : MonoBehaviour
    {
        [SerializeField] string _loadSceneName;
        [SerializeField] Button _button;

        // Start is called before the first frame update
        void Start()
        {
            _button.onClick.AddListener(() => SceneManager.LoadScene(_loadSceneName));
        }
    }
}
