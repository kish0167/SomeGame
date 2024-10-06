using System;
using UnityEngine;

namespace Game
{
    public abstract class Drop : MonoBehaviour
    {
        #region Events

        public static event Action<Drop> OnCreated;
        public static event Action<Drop> OnDestroyed;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            OnCreated?.Invoke(this);
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tag.Basket))
            {
                PerformCatchedActions();
            }
            else if (other.CompareTag(Tag.DeathZone))
            {
                PerformMissedActions();
            }

            Destroy(gameObject);
        }

        #endregion

        #region Protected methods

        protected virtual void PerformCatchedActions() { }

        protected virtual void PerformMissedActions() { }

        #endregion
    }
}