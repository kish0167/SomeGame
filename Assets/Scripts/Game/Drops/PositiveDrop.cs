using Services;
using UnityEngine;

namespace Game.Drops
{
    public class PositiveDrop : Drop
    {
        #region Variables

        [SerializeField] private int _scoreValue = 8;
        [SerializeField] private int _livesPenalty = -1;

        #endregion

        #region Protected methods

        protected override void PerformCatchedActions()
        {
            base.PerformCatchedActions();
            GameService.Instance.AddScore(_scoreValue);
        }

        protected override void PerformMissedActions()
        {
            base.PerformMissedActions();
            GameService.Instance.ChangeLife(_livesPenalty);
        }

        #endregion
    }
}