using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleChallengeSystem.Classes
{
    class State
    {
        // Information for the state
        private string _name;
        private bool _active;

        // Constructor to create custom states
        public State(string name)
        {
            _name = name;
            _active = false;
        }

        // Toggle active on and off
        public virtual void Toggle() { _active = !_active; }

        // Get the information of the state
        public string GetName() { return _name; }
        public bool isActive() { return _active; }
        public virtual string CurrentState()
        {
            return _active.ToString();
        }

    }
}
