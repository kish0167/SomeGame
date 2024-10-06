using Services;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid
{
    public class MenuScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Button _levelButtonPrefab;
        [SerializeField] private HorizontalLayoutGroup _levelSelector;
        [SerializeField] private Button _exitButton;
        [SerializeField] private AudioClip _menuTheme;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            AudioService.Instance.StopAll();
            AudioService.Instance.PlaySfx(_menuTheme);
        }

        #endregion

        #region Public methods

        public void ExitButtonClickedCallback()
        {
            SceneLoaderService.Instance.ExitGame();
        }

        #endregion
    }
}