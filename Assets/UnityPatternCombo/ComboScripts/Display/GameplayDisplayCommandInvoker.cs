using UnityEngine;
namespace Tutorial.PatternCombo
{
    /// <summary>
    /// Invokes display commands implementing the IGameplayDisplayCommand interface.
    /// 
    /// This class serves as a central point for executing display-related commands, ensuring that
    /// each display action is processed in a consistent manner. It is utilized by the
    /// ButtonDisplayController and DPadDisplayController to trigger the visual representation of button
    /// and DPad interactions in the game. The ExecuteCommand method is called whenever there is a need
    /// to update the display based on player input.
    /// </summary>
    public class GameplayDisplayCommandInvoker
    {
        public void ExecuteCommand(IGameplayDisplayCommand command)
        {
            command.ExecuteDisplay();
        }
    }
}
