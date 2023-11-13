using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleChallengeSystem.Classes;
using SampleChallengeSystem.PlayerTools;

namespace SampleChallengeSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // The trigger to indicate when to check for increasing challenges
            char trigger = ' ';

            // A sample player is premade and ready for your use
            // You can choose between FPS,
            // To change just comment the current active line, and uncomment the prebase you wish to choose
            // Making your own you have to comment all the prebases and an area is provided for you to make your own
            // Removing the /* at the beginning and the */ at the end enables that code

            // These are the sample players to use
            FPS_Sample newPlayer = new FPS_Sample();

            // You can create your own here

            /*
             
            Player newPlayer = new Player();

            // This is how you can add 'States' to the player
            // States allow requirements of challenges to be completed such as
            // Being a certain color or in a certain stance
            
            // This creates a state that is either on or off
            State stateName = new State("Sample State");

            // This creates a state that can toggle between several possible states
            SingleActionState singleActionStateName = new SingleActionState("Position", new State("Left"));
            singleActionStateName.AddState(new State("Center"));
            singleActionStateName.AddState(new State("Right"));

            // We need the states added to our player
            newPlayer.AddState(stateName);
            newPlayer.AddState(singleActionStateName);

            // To toggle the states we picked we just have to provide the name of the state we want
            newPlayer.ToggleState("Sample State");

            // Next we need commands to change the states of the player
            newPlayer.AddCommand('s', "Sample State");
            newPlayer.AddCommand('q', "Position");

            // Now we can create the challenges!!
            // With regualar states we have to assign it a true or false value
            // while with Single Action States we pick the value that needs to be true
            Challenge sampleChallenge = new Challenge();
            sampleChallenge.SetTitle("Sample Challenge");
            sampleChallenge.SetDescription("This is a samnple Challenge");
            sampleChallenge.AddRequirement("Sample State", true);
            sampleChallenge.AddRequirement("Position", "Right");
            newPlayer.AddChallenge(sampleChallenge);

            */

            // This runs the program to use the player
            Run(newPlayer, trigger);
        }

        static void Run(Player player, char trigger)
        {
            char input = ' ';

            while (input != 'q')
            {
                Console.Clear();

                player.ChallengeDisplay();
                player.StateDisplay();

                input = Console.ReadKey().KeyChar;
                player.Run(input);

                if (input == ' ')
                {
                    player.Trigger();
                }
            }
        }
    }
}
