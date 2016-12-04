using System;
using MilkCha.Util;
using Prism.Mvvm;
using Reactive.Bindings.Extensions;

namespace MilkCha.Model
{
    public class Game : BindableBase
    {
        private GameBoard _gameBoard;

        private int _emptyPiece;
        public int EmptyPiece
        {
            get { return _emptyPiece; }
            set { SetProperty(ref _emptyPiece, value); }
        }

        private int _playerScore;
        public int PlayerScore
        {
            get { return _playerScore; }
            set { SetProperty(ref _playerScore, value); }
        }
        
        private int _cpuScore;
        public int CpuScore
        {
            get { return _cpuScore; }
            set { SetProperty(ref _cpuScore, value); }
        }

        public void SetPiece(Tuple<int, int> position, PlayerList Player)
        {
            _gameBoard.SetColor(position.Item1,position.Item2,Player);
        }

        public Game(GameBoard gameBoard)
        {
            _gameBoard = gameBoard;

            _gameBoard.ObserveProperty(_ => _.Board)
                .Subscribe(_ =>
                {
                    EmptyPiece = _gameBoard.CountNoneColor;
                    PlayerScore = _gameBoard.CountBlackColor;
                    CpuScore = _gameBoard.CountWhiteColor;
                });
        }
    }
}
