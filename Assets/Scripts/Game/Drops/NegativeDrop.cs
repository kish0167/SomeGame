using Services;
using UnityEngine;

namespace Game.Drops
{
    public class NegativeDrop : Drop
    {
        #region Variables

        [SerializeField] private int _scoreValue = -32;

        #endregion

        #region Protected methods

        protected override void PerformCatchedActions()
        {
            GameService.Instance.AddScore(_scoreValue);
        }

        protected override void PerformMissedActions() { }

        #endregion
    }
}