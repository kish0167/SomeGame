using System.Collections.Generic;
using Game;
using Utility;

namespace Services
{
    public class LevelService : SingletonMonoBehaviour<LevelService>
    {
        #region Variables

        private Basket _basket;

        //private List<Drop> _drops;

        #endregion

        #region Unity lifecycle

        protected override void Awake()
        {
            base.Awake();
            Basket.OnCreated += BasketCreatedCallback;
            Basket.OnDestroyed += BasketDestroyedCallback;

            //Drop.OnCreated += DropCreatedCallback;
            //Drop.OnDestroyed += DropDestroyedCallback;
        }

        private void OnDestroy()
        {
            Basket.OnCreated -= BasketCreatedCallback;
            Basket.OnDestroyed -= BasketDestroyedCallback;

            //Drop.OnCreated -= DropCreatedCallback;
            //Drop.OnDestroyed -= DropDestroyedCallback;
        }

        #endregion

        #region Private methods

        private void BasketCreatedCallback(Basket basket)
        {
            _basket = basket;
        }

        private void BasketDestroyedCallback(Basket obj)
        {
            _basket = null;
        }

        /*private void DropCreatedCallback(Drop drop)
        {
            _drops.Add(drop);
        }

        private void DropDestroyedCallback(Drop drop)
        {
            _drops.Remove(drop);
        }*/

        #endregion
    }
}