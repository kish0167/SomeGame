using System;
using Services;
using UnityEngine;

namespace Game
{
    public class Basket : MonoBehaviour
    {
        #region Events

        public static event Action<Basket> OnCreated;
        public static event Action<Basket> OnDestroyed;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            OnCreated?.Invoke(this);
        }

        private void Update()
        {
            if (PauseService.Instance.IsPaused || GameService.Instance.IsGameOver)
            {
                return;
            }

            MoveWithMouse();
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }

        #endregion

        #region Private methods

        private void MoveWithMouse()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            SetXPosition(worldPosition.x);
        }

        private void SetXPosition(float x)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x = x;
            transform.position = currentPosition;
        }

        #endregion
    }
}