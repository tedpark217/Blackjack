using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Blackjack.Models;

namespace Blackjack.ViewModels
{
    public class BlackjackVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Card> PlayerCards { get; set; }
        public ObservableCollection<Card> DealerCards { get; set; }

        private int _playerPoint;
        public int PlayerPoint
        {
            get { return _playerPoint; }
            set 
            {
                _playerPoint = value;
                OnPropertyChanged("PlayerPoint");
            }
        }
        private int _dealerPoint;
        public int DealerPoint
        {
            get { return _dealerPoint; }
            set
            {
                _dealerPoint = value;
                OnPropertyChanged("DealerPoint");
            }
        }

        private string _result = string.Empty;
        public string Result
        {
            get { return _result; }
            set 
            {
                _result = value;
                OnPropertyChanged("Result");
            }
        }

        public Game game;

        private ICommand _startCommand;
        public ICommand StartCommand
        {
            get
            {
                return _startCommand;
            }
        }

        private ICommand _resetCommand;
        public ICommand ResetCommand
        {
            get
            {
                return _resetCommand;
            }
        }

        private ICommand _hitCommand;
        public ICommand HitCommand
        {
            get
            {
                return _hitCommand;
            }
        }

        private ICommand _standCommand;
        public ICommand StandCommand
        {
            get
            {
                return _standCommand;
            }
        }

        private bool StartedChecker;
        private bool StandChecker;
        private bool DealerTurnChecker;
        public BlackjackVM()
        {
            game = new Game();
            PlayerCards = new ObservableCollection<Card>();
            DealerCards = new ObservableCollection<Card>();
            PlayerCards.CollectionChanged += HandlePlayerChange;
            DealerCards.CollectionChanged += HandleDealerChange;

            _startCommand = new CommandHandler(() => Start(), null);
            _hitCommand = new CommandHandler(() => Hit(), checkHit);
            _standCommand = new CommandHandler(() => Stand(), checkStand);
            _resetCommand = new CommandHandler(() => Reset(), null);

            StartedChecker = false;
            StandChecker = false;
            DealerTurnChecker = false;  
        }

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void setUp()
        {
            PlayerCards.Clear();
            DealerCards.Clear();
            Result = string.Empty;
            PlayerPoint = 0;
            DealerPoint = 0;

            StartedChecker = false;
            StandChecker = false;
            DealerTurnChecker = false;
        }

        private void updateScore()
        {
            PlayerPoint = this.game.getScore(PlayerCards.ToList());
            DealerPoint = this.game.getScore(DealerCards.ToList());
        }

        private void checkWinner()
        {
            if ((DealerPoint <= 21 && DealerPoint > PlayerPoint) || PlayerPoint > 21)
            {
                Result = "DEALER WIN";
            }
            else if (PlayerPoint == DealerPoint)
            {
                Result = "TIED";
            }
            else
            {
                Result = "PLAYER WIN";
            }
        }
        private void HandlePlayerChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            updateScore();
        }

        private void HandleDealerChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            updateScore();
        }

        public async void Start()
        {
            setUp();

            PlayerCards.Add(this.game.deal());
            await Task.Delay(500);
            DealerCards.Add(this.game.deal());
            await Task.Delay(500);
            PlayerCards.Add(this.game.deal());
            await Task.Delay(500);

            Card fdCard = this.game.deal();
            fdCard.FaceDown = true;
            DealerCards.Add(fdCard);
            await Task.Delay(500);

            StartedChecker = true;
            StandChecker = false;
            RaiseCanExecuteChanged();
        }

        public async void Hit()
        {
            PlayerCards.Add(this.game.deal());
            RaiseCanExecuteChanged();
            if (PlayerPoint >= 21)
            {
                await Task.Delay(500);
                OpenFlipped();
                updateScore();
                checkWinner();
            }
        }

        public bool checkHit()
        {
            if (!StartedChecker)
            {
                return false;
            }
            if (PlayerPoint >= 21)
            {
                return false;
            }
            if (StandChecker)
            {
                return false;
            }
            return true;
        }

        public async void Stand()
        {
            StandChecker = true;
            RaiseCanExecuteChanged();
            await Task.Delay(500);
            DealerDeal();
        }

        public async void OpenFlipped()
        {
            DealerTurnChecker = true;
            RaiseCanExecuteChanged();
            foreach (Card c in DealerCards)
            {
                c.FaceDown = false;
            }
            updateScore();
            await Task.Delay(500);
        }
        public async void DealerDeal()
        {
            OpenFlipped();
            if(DealerPoint > PlayerPoint)
            {
                checkWinner();
                return;
            }

            await Task.Delay(500);
            while (DealerPoint <= 17)
            {
                DealerCards.Add(this.game.deal());
                await Task.Delay(500);
            }
            checkWinner();
        }

        public bool checkStand()
        {
            if (StandChecker)
            {
                return false;
            }
            if (DealerTurnChecker || !StartedChecker)
            {
                return false;
            }
            return true;
        }

        public void Reset()
        {
            setUp();
            RaiseCanExecuteChanged();
        }
        private void RaiseCanExecuteChanged()
        {
            (StartCommand as CommandHandler).RaiseCanExecuteChanged();
            (HitCommand as CommandHandler).RaiseCanExecuteChanged();
            (StandCommand as CommandHandler).RaiseCanExecuteChanged();
            (ResetCommand as CommandHandler).RaiseCanExecuteChanged();
        }
    }
    public class CommandHandler : ICommand
    {
        private Action _action;
        private Func<bool> _evaluator;
        public CommandHandler(Action action, Func<bool> function)
        {
            _action = action;
            _evaluator = function;
        }

        public bool CanExecute(object parameter)
        {
            if (_evaluator == null)
            {
                return true;
            }
            else
            {
                bool result = _evaluator.Invoke();
                return result;
            }
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }

        public void Execute(object parameter)
        {
            RaiseCanExecuteChanged();
            _action();
        }
    }
}
