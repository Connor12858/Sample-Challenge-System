using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleChallengeSystem.Classes
{
    class SingleActionState : State
    {
        // A list of states where only 1 can be active
        private List<State> states;
        private int _active;

        // Constructor for ;)
        public SingleActionState(string name, State firstSate) : base(name)
        {
            _active = 0;
            states = new List<State>
            {
                firstSate
            };

            states[0].Toggle();
        }

        // Add states that are on it
        public void AddState(State state) 
        {  
            states.Add(state); 
        }

        // Change the toggle to rotate
        public override void Toggle()
        {
            // Toggle the before
            states[_active].Toggle();
            
            // Change to the next state
            if (_active < states.Count - 1)
            {
                _active++;
            } else
            {
                _active = 0;
            }

            // Toggle after change
            states[_active].Toggle();
        }

        // Methods for activeness and getting names
        public override string CurrentState()
        {
            // Find the state that is active and return name
            foreach (State state in states)
            {
                if (state.isActive())
                {
                    return state.GetName();
                }
            }

            // Return nothing
            return "";
        }
    }
}
