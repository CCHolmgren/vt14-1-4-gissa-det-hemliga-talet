using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GissaHemligtTal
{
    /// <summary>
    /// enum representing the Outcome of the guessing
    /// </summary>
    public enum Outcome
    {
        Indefinite,
        Low,
        High,
        Correct,
        NoMoreGuesses,
        PreviousGuess
    }

    public class SecretNumber
    {
        const int MaxNumberOfGuesses = 7;
        int _number;
        List<int> _previousGuesses;

        /// <summary>
        /// CanMakeGuess returns true if you can still guess
        /// </summary>
        bool CanMakeGuess
        {
            get
            {
                //NoMoreGuesses and Correct are the two Outcomes that stops the guessing
                return Outcome != GissaHemligtTal.Outcome.NoMoreGuesses && Outcome != GissaHemligtTal.Outcome.Correct;
            }
        }
        /// <summary>
        /// Returns _previousGuesses.Count
        /// </summary>
        int Count
        {
            get
            {
                return _previousGuesses.Count;
            }
        }
        /// <summary>
        /// Returns null unless CanMakeGuess returns false
        /// </summary>
        public int? Number
        {
            get
            {
                //If we still can make a guess then we must return null so no cheating is happening
                if (CanMakeGuess)
                    return null;
                return _number;
            }
        }
        /// <summary>
        /// Last guess' outcome
        /// </summary>
        Outcome Outcome
        {
            get;
            set;
        }
        /// <summary>
        /// We don't want to send off a list since it can be modified, so we use a ReadOnlyCollection instead
        /// </summary>
        public IEnumerable<int> PreviousGuesses
        {
            get
            {
                return _previousGuesses.AsReadOnly();
            }
        }
        /// <summary>
        /// Initializes the values so we can start from the beginning
        /// </summary>
        public void Initialize()
        {
            Random random = new Random();
            _number = random.Next(1, 101);
            _previousGuesses.Clear();
            Outcome = GissaHemligtTal.Outcome.Indefinite;
        }
        /// <summary>
        /// Takes an integer representing the guess
        /// Returns Outcome represnting the outcome of the guess
        /// </summary>
        /// <param name="guess"></param>
        /// <returns></returns>
        public Outcome MakeGuess(int guess)
        {
            //If we somehow didn't return NoMoreGuesses last time we do it now instead
            if (!CanMakeGuess)
            {
                Outcome = GissaHemligtTal.Outcome.NoMoreGuesses;
            }
            //If the guess is outside out [1,100] we throw an exception
            else if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            //If the guess has already been guessed before
            else if (_previousGuesses.Contains(guess))
            {
                Outcome = GissaHemligtTal.Outcome.PreviousGuess;
            }
            //If we guessed correct
            else if (guess == _number)
            {
                _previousGuesses.Add(guess);
                Outcome = GissaHemligtTal.Outcome.Correct;
            }
            //If the amount of guesses is 6, and it wasn't correct then you got no more guesses left
            else if (Count == MaxNumberOfGuesses - 1)
            {
                _previousGuesses.Add(guess);
                Outcome = GissaHemligtTal.Outcome.NoMoreGuesses;
            }
            else if (guess > _number)
            {
                _previousGuesses.Add(guess);
                Outcome = GissaHemligtTal.Outcome.High;
            }
            else if (guess < _number)
            {
                _previousGuesses.Add(guess);
                Outcome = GissaHemligtTal.Outcome.Low;
            }
            //Return the Outcome to DRY
            return Outcome;
        }
        /// <summary>
        /// Initialize the Object with a _previosuGuesses of length 7 and then calls Initialize
        /// </summary>
        public SecretNumber()
        {
            _previousGuesses = new List<int>(7);
            Initialize();
        }

    }
}