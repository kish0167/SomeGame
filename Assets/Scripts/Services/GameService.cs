using System;
using System.Collections;
using Utility;
using UnityEngine;

namespace Services
{
    public class GameService : SingletonMonoBehaviour<GameService>
    {
        #region Variables
        [Header("Settings")]
        [SerializeField] private int _startLives = 5;
        
        [Header("Stats")]
        [SerializeField] private int _score;
        [SerializeField] private int _lives;
        
        [Header("SFX")]
        [SerializeField] private AudioClip _gameOverSfx;
        

        #endregion

        #region Events

        public event Action OnGameOver;
        public event Action OnLivesChanged;

        public event Action<int> OnScoreChanged;

        #endregion

        #region Properties
        public bool IsGameOver { get; set; }

        public int Lives => _lives;
        public int Score => _score;

        #endregion

        #region Unity lifecycle

        protected override void Awake()
        {
            base.Awake();

            ResetLives();
            IsGameOver = false;
        }

        private void Start()
        {
            
        }

        private void OnDestroy()
        {
            
        }

        #endregion

        #region Public methods

        public void AddScore(int value)
        {
            if (IsGameOver)
            {
                return;
            }

            _score += value;
            OnScoreChanged?.Invoke(_score);
        }

        public void ChangeLife(int value)
        {
            if (IsGameOver)
            {
                return;
            }

            if (_lives + value < 0)
            {
                _lives = 0;
            }
            else
            {
                _lives += value;
            }

            OnLivesChanged?.Invoke();
            GameOverCheck();
        }

        public void ResetLives()
        {
            _lives = _startLives;
            OnLivesChanged?.Invoke();
        }

        #endregion

        #region Private methods
        private void GameOverCheck()
        {
            if (_lives > 0)
            {
                return;
            }
            
            GameOver();
        }

        private void GameOver()
        {
            IsGameOver = true;
            AudioService.Instance.PlaySfx(_gameOverSfx);
            OnGameOver?.Invoke();
        }

        public void GameRestart()
        {
            IsGameOver = false;
            ResetLives();
            SceneLoaderService.Instance.LoadStartScene();
        }
        
        private void ResetScore()
        {
            _score = 0;
            OnScoreChanged?.Invoke(_score);
        }

        #endregion
    }
}