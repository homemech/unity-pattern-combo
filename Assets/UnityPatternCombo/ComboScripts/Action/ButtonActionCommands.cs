namespace Tutorial.PatternCombo
{
    /// <summary>
    /// Contains concrete implementations of IGameplayActionCommand for button actions.
    /// Each command encapsulates a specific action triggered by player input, which can be executed in-game.
    ///
    /// These commands form the building blocks for the game's input system and are used to map player
    /// inputs to their corresponding actions. This modular approach facilitates flexible input rebinding
    /// and ease of extending the game with additional actions or behaviours.
    ///
    /// By injecting dependencies (like e.g., playerCharacter below), we allow for greater flexibility and
    /// testability of our command objects. This follows the Command pattern, which helps in
    /// queuing, logging actions, and undo operations.
    /// </summary>
    public class DPadUpActionCommand : IGameplayActionCommand
    {
        // Example: Injecting a PlayerCharacter dependency
        // private PlayerCharacter _playerCharacter;

        // Example: Constructor with PlayerCharacter parameter
        // public DPadUpActionCommand(PlayerCharacter playerCharacter)
        // {
        //     _playerCharacter = playerCharacter;
        // }

        public void ExecuteAction()
        {
            // Example: Actual game logic for the character jump
            // _playerCharacter.Jump();
        }
    }

    public class DPadDownActionCommand : IGameplayActionCommand
    {
        public void ExecuteAction()
        {
            //...
        }
    }

    public class DPadLeftActionCommand : IGameplayActionCommand
    {
        public void ExecuteAction()
        {
            //...
        }
    }

    public class DPadRightActionCommand : IGameplayActionCommand
    {
        public void ExecuteAction()
        {
            //...
        }
    }

    public class XButtonActionCommand : IGameplayActionCommand
    {
        public void ExecuteAction()
        {
            //...
        }
    }

    public class YButtonActionCommand : IGameplayActionCommand
    {
        public void ExecuteAction()
        {
            //...
        }
    }

    public class AButtonActionCommand : IGameplayActionCommand
    {
        public void ExecuteAction()
        {
            //...
        }
    }

    public class BButtonActionCommand : IGameplayActionCommand
    {
        public void ExecuteAction()
        {
            //...
        }
    }
}
