using UnityEngine;
namespace Tutorial.PatternCombo
{
    /// <summary>
    /// ***Factory class*** for creating combo-related gameplay action command objects.
    /// 
    /// This encapsulates the object creation process, allowing for easy addition
    /// and management of new gameplay action commands. By using a factory, we keep our
    /// system flexible and scalable, following the Open/Closed principle where the system
    /// is open for extension but closed for modification.
    /// </summary>
    public class ComboActionCommandFactory : MonoBehaviour
    {
        public IGameplayActionCommand CreateDashAttackCommand()
        {
            return new DashAttackActionCommand();
        }

        public IGameplayActionCommand CreateJumpKickCommand()
        {
            return new JumpKickActionCommand();
        }

        // Example of how to extend the factory with a new command:
        // public IGameplayActionCommand CreateSlideAttackCommand()
        // {
        //     return new SlideAttackActionCommand();
        // }
    }
}