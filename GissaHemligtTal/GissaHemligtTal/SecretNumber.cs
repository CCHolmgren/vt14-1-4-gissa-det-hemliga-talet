using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GissaHemligtTal
{
    public enum Outcome
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
        public List<int> _previousGuesses;

        bool CanMakeGuess
        {
            get
            {
                return _previousGuesses.Count < MaxNumberOfGuesses;
            }
        }
        int Count
        {
            get
            {
                return _previousGuesses.Count;
            }
        }
        public int? Number
        {
            get
            {
                if (Count < MaxNumberOfGuesses)
                    return null;
                return _number;
            }
        }
        Outcome Outcome
        {
            get;
            set;
        }
        public IEnumerable<int> PreviousGuesses
        {
            get
            {
                return _previousGuesses.AsReadOnly();
            }
        }
        public void Initialize()
        {
            Random random = new Random();
            _number = random.Next(1, 101);
            _previousGuesses.Clear();
            Outcome = GissaHemligtTal.Outcome.Indefinite;
        }
        public Outcome MakeGuess(int guess)
        {
            if (!CanMakeGuess)
                return GissaHemligtTal.Outcome.NoMoreGuesses;
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (_previousGuesses.Contains(guess))
            {
                return GissaHemligtTal.Outcome.PreviosuGuess;
            }
            if (guess == _number)
            {
                //_previousGuesses.Add(guess);
                return GissaHemligtTal.Outcome.Correct;
            }
            if (Count == MaxNumberOfGuesses - 1)
            {
                return GissaHemligtTal.Outcome.NoMoreGuesses;
            }
            if (guess > _number)
            {
                _previousGuesses.Add(guess);
                return GissaHemligtTal.Outcome.High;
            }
            if (guess < _number)
            {
                _previousGuesses.Add(guess);
                return GissaHemligtTal.Outcome.Low;
            }

              //  return GissaHemligtTal.Outcome.Indefinite;

            //    return GissaHemligtTal.Outcome.NoMoreGuesses;

            return GissaHemligtTal.Outcome.Indefinite;
        }
        public SecretNumber()
        {
            _previousGuesses = new List<int>(7);
            Initialize();
        }

    }
}