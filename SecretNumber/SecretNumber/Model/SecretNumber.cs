using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;

namespace SecretNumber.Model
{
    public class SecretNumber
    {

        private int? _number;
        private List<int> _previousGuesses;
        private const int MaxNumberOfGuesses = 7;

#region properties
        public bool CanMakeGuess { get; }
        public int Count { get; }
        public Outcome Outcome { get; private set; }
        
        public int? Number
        {
            get { 
                return _number; 
            }
            private set { 
                _number = value; 
            }
        }
        public ReadOnlyCollection<int> PreviousGuesses { 
            get { 
                return _previousGuesses.AsReadOnly(); 
            } 
        }
#endregion properties

        public SecretNumber()
        {
        }
        public void Initialize()
        {
            Number = new Random().Next(1, 101);

        }
    }
    private enum Outcome
    {
        Indefinite,
        Low,
        High,
        Correct,
        NoMoreGuesses,
        PreviousGuess
    }
}