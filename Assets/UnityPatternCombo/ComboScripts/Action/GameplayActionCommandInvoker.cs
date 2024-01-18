using System.Collections;
using System.Collections.Generic;

namespace Tutorial.PatternCombo
{
    /// <summary>
    /// Invokes action commands implementing the IGameplayActionCommand interface.
    /// 
    /// This class acts as a central hub for executing gameplay action commands, providing a
    /// consistent execution point for various gameplay actions initiated by the player. It is
    /// primarily utilized within the ButtonActionController to process and enact player input into
    /// actionable commands in the game environment.
    /// </summary>
    public class GameplayActionCommandInvoker
    {
        public void ExecuteCommand(IGameplayActionCommand command)
        {
            command.ExecuteAction();
        }
    }
}
