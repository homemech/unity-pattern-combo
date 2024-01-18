using System.Collections;
using System.Collections.Generic;
using Tutorial.PatternCombo;
using UnityEngine;

namespace Tutorial.PatternCombo
{
    /// <summary>
    /// Maps player's game input to specific gameplay action commands.
    /// 
    /// This class listens for button press events and translates them into corresponding action commands.
    /// These commands are then queued for potential combination with other actions to form complex commands, like combos.
    /// 
    /// By using the Command pattern, this controller decouples the button press events from the action execution,
    /// allowing for flexible command management and potential extension of the input system.
    /// </summary>
    public class ButtonActionController : MonoBehaviour
    {
        private SideFighterControls _gameplayControls;
        private GameplayActionCommandInvoker _actionInvoker;
        private ComboActionQueueManager _queueManager;

        /// <summary>
        /// Initializes the controller with the necessary dependencies for action command processing.
        /// </summary>
        /// <param name="gameplayControls">The controls setup for the game.</param>
        /// <param name="invoker">The invoker responsible for command execution.</param>
        /// <param name="queueManager">The manager handling the command queue for combos.</param>

        public void Initialize(SideFighterControls gameplayControls, GameplayActionCommandInvoker invoker, 
            ComboActionQueueManager queueManager)
        {
            _gameplayControls = gameplayControls;
            _actionInvoker = invoker;
            _queueManager = queueManager;
            SetupActions();
        }

        // Registers button press event handlers that create and process action commands.
        private void SetupActions()
        {
            _gameplayControls.gameplay.x.performed += ctx => HandleXButtonActionCommand();
            _gameplayControls.gameplay.y.performed += ctx => HandleYButtonActionCommand();
            _gameplayControls.gameplay.a.performed += ctx => HandleAButtonActionCommand();
            _gameplayControls.gameplay.b.performed += ctx => HandleBButtonActionCommand();
        }

        // Below are handlers for each button press. They create a new command instance specific to the button,
        // add it to the combo sequence, and then execute the command.
        private void HandleXButtonActionCommand()
        {
            var xButtonCommand = new XButtonActionCommand();
            AddToComboSequence(xButtonCommand);
            ExecuteActionCommand(xButtonCommand);
        }

        private void HandleYButtonActionCommand()
        {
            var yButtonCommand = new YButtonActionCommand();
            AddToComboSequence(yButtonCommand);
            ExecuteActionCommand(yButtonCommand);
        }

        private void HandleAButtonActionCommand()
        {
            var aButtonCommand = new AButtonActionCommand();
            AddToComboSequence(aButtonCommand);
            ExecuteActionCommand(aButtonCommand);
        }

        private void HandleBButtonActionCommand()
        {
            var bButtonCommand = new BButtonActionCommand();
            AddToComboSequence(bButtonCommand);
            ExecuteActionCommand(bButtonCommand);
        }


        // Adds the given command to the sequence being tracked for combo possibilities.
        private void AddToComboSequence(IGameplayActionCommand command)
        {
            _queueManager.AddCommandToComboSequence(command);
        }

        private void ExecuteActionCommand(IGameplayActionCommand command)
        {
            _actionInvoker.ExecuteCommand(command);
        }
    }
}
