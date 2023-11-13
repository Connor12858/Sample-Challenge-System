using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SampleChallengeSystem.Classes
{
    internal class Challenge
    {
        // Create the needed information for the challenge
        private string _title;
        public string Title { get => _title; }
        private string _description;
        public string Description { get => _description; }
        private int _goal;
        public int Goal { get => _goal; }
        private int _current;
        public int Current { get => _current; }
        private Dictionary<string, dynamic> _requirements = new Dictionary<string, dynamic>();
        public Dictionary<string, dynamic> Requirements { get => _requirements; }
        private bool _done;

        // Constructor to build it
        public Challenge(string title="", string description="", int goal=0)
        {
            _title = title;
            _description = description;
            _goal = goal;
            _current = 0;
            _done = false;
        }

        // Allow the user to set the information via methods
        public void SetTitle(string newTitle)
        {
            _title = newTitle.Trim();
        }
        public void SetDescription(string newDescription)
        {
            _description = newDescription.Trim();
        }
        public void SetGoal(int newGoal)
        {
            _goal = newGoal;
        }
        public void AddRequirement(string state, dynamic requirement)
        {
            _requirements.Add(state, requirement);
        }

        // Increate the current and check if it is completed
        public void IncreaseCurrent()
        {
            // Only if not done can we increase
            if (!_done)
            {
                _current++;
            }

            //Check if it is completed
            if (_current == _goal)
            {
                _done = true;
            }
        }
    }
}
