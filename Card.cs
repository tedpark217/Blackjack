using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Blackjack.Models
{   
    public class Card : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _faceNumber;
        public int FaceNumber
        {
            get { return _faceNumber; }
            set
            {
                _faceNumber = value;
                OnPropertyChanged("FaceNumber");
                switch (_faceNumber)
                {
                    case 1:
                        FaceString = "ace";
                        break;
                    case 2:
                        FaceString = Convert.ToString(_faceNumber);
                        break;
                    case 3:
                        FaceString = Convert.ToString(_faceNumber);
                        break;
                    case 4:
                        FaceString = Convert.ToString(_faceNumber);
                        break;
                    case 5:
                        FaceString = Convert.ToString(_faceNumber);
                        break;
                    case 6:
                        FaceString = Convert.ToString(_faceNumber);
                        break;
                    case 7:
                        FaceString = Convert.ToString(_faceNumber);
                        break;
                    case 8:
                        FaceString = Convert.ToString(_faceNumber);
                        break;
                    case 9:
                        FaceString = Convert.ToString(_faceNumber);
                        break;
                    case 10:
                        FaceString = Convert.ToString(_faceNumber);
                        break;
                    case 11:
                        FaceString = "jack";
                        break;
                    case 12:
                        FaceString = "queen";
                        break;
                    case 13:
                        FaceString = "king";
                        break;
                }
            }
        }

        private string _faceString;
        public string FaceString
        {
            get { return _faceString; }
            set
            {
                _faceString = value;
                OnPropertyChanged("FaceString");
            }
        }

        private string _suit;
        public string Suit
        {
            get { return _suit; }
            set
            {
                _suit = value;
                OnPropertyChanged("Suit");
            }
        }
        private bool _faceDown = false;
        public bool FaceDown
        {
            get { return _faceDown; }
            set 
            {  
                _faceDown = value;
                OnPropertyChanged("FaceDown");
            }
        }
        public Card(int newFaceNumber, string newSuit)
        {
            FaceNumber = newFaceNumber;
            Suit = newSuit;
        }

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
