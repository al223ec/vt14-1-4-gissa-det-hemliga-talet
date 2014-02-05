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
        public bool CanMakeGuess
        {
            get
            {
                return ((Count < MaxNumberOfGuesses && Outcome != Outcome.Correct) && Outcome != Outcome.NoMoreGuesses);
            }
        }
        public int Count { get { return _previousGuesses.Count; } }
        public Outcome Outcome { get; private set; }
        public int? Number
        {
            get
            {
                return _number;
            }
            private set
            {
                _number = value;
            }
        }
        public ReadOnlyCollection<int> PreviousGuesses
        {
            get
            {
                return _previousGuesses.AsReadOnly();
            }
        }
#endregion properties

        public SecretNumber() 
        {
            Initialize(); 
        }
        public void Initialize()
        {
            _previousGuesses = new List<int>();
            Number = new Random().Next(1, 101);
            Outcome = Outcome.Indefinite;
        }

        public Outcome MakeGuess(int guessedNumber)
        {
            if (Count >= MaxNumberOfGuesses)//Ganska onödigt egentligen...eller?
            {
                return Outcome = Outcome.NoMoreGuesses;
            }
            if (guessedNumber < 1 || guessedNumber > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (CanMakeGuess)
            {
                //kontrollerar ifall talet har gissats förut
                if (_previousGuesses.Contains(guessedNumber))
                {
                    return Outcome = Outcome.PreviousGuess;
                }

                if (guessedNumber < Number)
                {
                    Outcome = Outcome.Low;
                }
                else if (guessedNumber > Number)
                {
                    Outcome = Outcome.High;
                }
                else
                {
                    Outcome = Outcome.Correct;
                }
                _previousGuesses.Add(guessedNumber);
            }
            return Outcome;
        }
        //public static string getEnumResourceString(Enum value)
        //{
        //    System.Reflection.FieldInfo fi = value.GetType().GetField(value.ToString());
        //    EnumResourceAttribute attr = (EnumResourceAttribute)System.Attribute.GetCustomAttribute(fi, typeof(EnumResourceAttribute));
        //    return (string)HttpContext.GetGlobalResourceObject(attr.BaseName, attr.Key);
        //}
    }
    public enum Outcome
    {
        Indefinite,
        Low,
        High,
        Correct,
        NoMoreGuesses, 
        PreviousGuess
    }
}

public static class ErrorLevelExtensions
{
    public static string toTextString(this SecretNumber.Model.Outcome outcome)
    {
        switch (outcome)
        {
            case SecretNumber.Model.Outcome.Low:
                return "Denna gissning var för låg";
            case SecretNumber.Model.Outcome.High:
                return "Denna gissning var för hög";
            case SecretNumber.Model.Outcome.Correct:
                return "Du gissade rätt!!";
            case SecretNumber.Model.Outcome.PreviousGuess:
                return "Detta tal har du gissat på förut!";
            case SecretNumber.Model.Outcome.NoMoreGuesses:
                return "Du har förbrukat alla dina gissningar";
            default:
                throw new ArgumentException();
        }
    }
}