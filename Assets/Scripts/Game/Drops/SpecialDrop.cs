using Services;
using UnityEngine;

namespace Game.Drops
{
    public class SpecialDrop : Drop
    {
        #region Variables

        [SerializeField] private int _livesToAdd = 1;

        #endregion

        #region Protected methods

        protected override void PerformCatchedActions()
        {
            base.PerformCatchedActions();
            GameService.Instance.ChangeLife(_livesToAdd);
        }

        protected override void PerformMissedActions() { }

        #endregion
    }
}