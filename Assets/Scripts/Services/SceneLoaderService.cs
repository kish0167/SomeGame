using UnityEngine;
using UnityEngine.SceneManagement;
using Utility;

namespace Services
{
    public class SceneLoaderService : SingletonMonoBehaviour<SceneLoaderService>
    {
        #region Variables

        [SerializeField] private string _startSceneName;
        [SerializeField] private string _gameSceneName;

        #endregion

        #region Unity lifecycle

        protected override void Awake()
        {
            base.Awake();
        }

        #endregion

        #region Public methods

        public void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }

        public void LoadGameScene()
        {
            SceneManager.LoadScene(_gameSceneName);
        }

        public void LoadStartScene()
        {
            SceneManager.LoadScene(_startSceneName);
            Debug.LogError("??????");
        }

        #endregion
    }
}