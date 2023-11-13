using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleChallengeSystem.Classes;

namespace SampleChallengeSystem.PlayerTools
{
    class Player
    {
        // Able to contain multiple challenges and states
        private List<Challenge> _playerChallenges = new List<Challenge>();
        private List<State> _state = new List<State>();
        private Dictionary<char, string> _commands = new Dictionary<char, string>();

        // Constructor is blank because we don't need information
        public Player()
        {

        }

        // Add a command to the dictonary
        public void AddCommand(char command, string state)
        {
            _commands.Add(command, state);
        }

        // Run the command based on the given input
        public void Run(char input)
        {
            foreach (var command in _commands)
            {
                if (command.Key == input)
                {
                    ToggleState(command.Value);
                }
            }
        }

        // Check for increasing challenge stats
        public void Trigger()
        {
            // Make a dictionary to compare
            Dictionary<string, string> currentStates = new Dictionary<string, string>();

            // Go through and forumlate the dic
            foreach (var state in _state)
            {
                currentStates.Add(state.GetName(), state.CurrentState());
            }

            // Check each challenge and compare
            foreach (var challenge in  _playerChallenges)
            {
                if (CompareDictionaries(currentStates, challenge.Requirements))
                {
                    challenge.IncreaseCurrent();
                }
            }

            // Remove completed challenges
            for (int i = 0; i < _playerChallenges.Count; i++)
            {
                if (_playerChallenges[i].Current == _playerChallenges[i].Goal)
                {
                    _playerChallenges.Remove(_playerChallenges[i]);
                    i--;
                }
            }
        }

        // Check if a dictionary matches the content of another dictionary
        private bool CompareDictionaries(Dictionary<string, string> states, Dictionary<string, dynamic> require)
        {
            bool isMatched = true;

            foreach (var key in require)
            {
                string value;
                if (states.TryGetValue(key.Key, out value))
                {
                    if (value !=  key.Value.ToString())
                    {
                        isMatched = false;
                    }
                }
                else
                {
                    isMatched = false;
                }
            }

            return isMatched;
        }

        // Get all of the states
        public List<State> States ()
        {
            return _state;
        }

        // Toggle the state that matches the name
        public void ToggleState(string name)
        {
            foreach (var state in _state)
            {
                if (state.GetName().Equals(name))
                {
                    state.Toggle();
                }
            }
        }

        // Be able to add/remove to our challenges, states, etc
        public void AddChallenge(Challenge challenge)
        {
            _playerChallenges.Add(challenge);
        }
        public void AddState(State state)
        {
            _state.Add(state);
        }
        public void RemoveChallenge(Challenge challenge)
        {
            _playerChallenges.Remove(challenge);
        }
        public void RemoveState(State state)
        {
            _state.Remove(state);
        }

        // Displays allow a nice view of the current active states and challenges
        public virtual void StateDisplay()
        {
            foreach (var state in _state)
            {
                Console.Write(state.GetName() + ": ");
                Console.WriteLine(state.CurrentState());
            }
        }

        public virtual void ChallengeDisplay()
        {
            foreach (var challenge in _playerChallenges)
            {
                Console.WriteLine(challenge.Title);
                Console.WriteLine(challenge.Description);
                Console.WriteLine(challenge.Current.ToString() + "/" + challenge.Goal.ToString());
                Console.WriteLine("==============\n");
            }
        }
    }
}
