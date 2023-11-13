using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SampleChallengeSystem.Classes;

namespace SampleChallengeSystem.PlayerTools
{
    class FPS_Sample : Player
    {
        // Constructor to add the default states
        public FPS_Sample()
        {
            // Create the stance state for if the player is crouching, prone, or standing
            SingleActionState stanceState = new SingleActionState("Stance", new State("Standing"));
            stanceState.AddState(new State("Prone"));
            stanceState.AddState(new State("Crouch"));
            AddState(stanceState);

            // Create the aim state for if the player is aiming or hipfiring
            SingleActionState aimState = new SingleActionState("Aim", new State("Hipfire"));
            aimState.AddState(new State("ADS"));
            AddState(aimState);

            // Create the commands for both states
            AddCommand('s', "Aim");
            AddCommand('a', "Stance");

            // Create the sample challenges
            Challenge CrouchHipfire = new Challenge();
            CrouchHipfire.SetTitle("Aim Hacker");
            CrouchHipfire.SetDescription("Get 20 Hipfire Kills while crouching");
            CrouchHipfire.AddRequirement("Stance", "Crouch");
            CrouchHipfire.AddRequirement("Aim", "Hipfire");
            CrouchHipfire.SetGoal(20);
            AddChallenge(CrouchHipfire);

            Challenge ADSKills = new Challenge();
            ADSKills.SetTitle("Special Forces");
            ADSKills.SetDescription("Get 100 kills while ADS");
            ADSKills.AddRequirement("Aim", "ADS");
            ADSKills.SetGoal(100);
            AddChallenge(ADSKills);

            Challenge Sniper = new Challenge();
            Sniper.SetTitle("Camper");
            Sniper.SetDescription("Get 5 kills prone and ADS");
            Sniper.AddRequirement("Aim", "ADS");
            Sniper.AddRequirement("Stance", "Prone");
            Sniper.SetGoal(5);
            AddChallenge(Sniper);
        }
    }
}
