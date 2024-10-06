using Services;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid
{
    public class MenuScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Button _startButton;
        [SerializeField] private Button _exitButton;

        [SerializeField] private AudioClip _menuTheme;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            AudioService.Instance.StopAll();
            AudioService.Instance.PlaySfx(_menuTheme);
            
            _startButton.onClick.AddListener(StartButtonClickedCallback);
            _exitButton.onClick.AddListener(ExitButtonClickedCallback);
        }

        #endregion

        #region Public methods

        public void ExitButtonClickedCallback()
        {
            SceneLoaderService.Instance.ExitGame();
        }
        
        public void StartButtonClickedCallback()
        {
            SceneLoaderService.Instance.LoadGameScene();
        }

        #endregion
    }
}