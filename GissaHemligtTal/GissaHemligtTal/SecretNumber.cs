using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GissaHemligtTal
{
    enum Outcome
    {
        Indefinite,
        Low,
        High,
        Correct,
        NoMoreGuesses,
        PreviosuGuess
    }
    public class SecretNumber
    {
        const int MaxNumberOfGuesses = 7;
        int _number;
        List<int> _previousGuesses;

        bool CanMakeGuess
        {
            get;
        }
        int Count
        {
            get
            {
                return _previousGuesses.Count;
            }
        }
        int? Number
        {
            get
            {
                if (CanMakeGuess)
                    return null;
                return _number;
            }
        }
        Outcome Outcome
        {
            get;
            set;
        }
        IEnumerable<int> PreviousGuesses
        {
            get
            {
                return _previousGuesses.AsReadOnly();
            }
        }
        void Initialize()
        {
            Random random = new Random();
            _number = random.Next(1, 101);
            _previousGuesses.Clear();
            Outcome = GissaHemligtTal.Outcome.Indefinite;
        }
        Outcome MakeGuess(int guess)
        {
            if (CanMakeGuess)
            {
                if (guess < 1 || guess > 100)
                    throw new ArgumentOutOfRangeException();
                if (_previousGuesses.Contains(guess))
                    return GissaHemligtTal.Outcome.PreviosuGuess;
                if (guess == _number)
                    return GissaHemligtTal.Outcome.Correct;
                if (guess > _number)
                    return GissaHemligtTal.Outcome.High;
                if (guess < _number)
                    return GissaHemligtTal.Outcome.Low;
            }
            else
                return GissaHemligtTal.Outcome.NoMoreGuesses;
        }
        SecretNumber()
        {
            _previousGuesses = new List<int>(7);
            Initialize();
        }

    }
}