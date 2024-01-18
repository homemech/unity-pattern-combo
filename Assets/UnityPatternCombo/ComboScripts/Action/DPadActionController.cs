using System.Collections;
using System.Collections.Generic;
using Tutorial.PatternCombo;
using UnityEngine;
namespace Tutorial.PatternCombo
{
    public enum DPadDirection
    {
        None,
        Up,
        Down,
        Left,
        Right
    }
    /// <summary>
    /// Handles directional pad (D-Pad) inputs and converts them into gameplay actions.
    /// 
    /// This class is responsible for translating D-Pad directions into corresponding
    /// commands. It is separated from button action handling to keep classes small
    /// and focused, allowing for a clearer and more maintainable codebase. 
    /// 
    /// The D-Pad often involves distinct logic compared to other buttons, such as continuous
    /// input or directional combinations, which are not necessary for the simpler
    /// button actions. Additionally, this separation provides flexibility in supporting
    /// controller configurations that may not include a D-Pad or use different input
    /// mechanisms for directional input.
    /// </summary>
    public class DPadActionController : MonoBehaviour
    {
        private SideFighterControls _gameplayControls;
        private GameplayActionCommandInvoker _invoker;
        private ComboActionQueueManager _queueManager;

        private Vector2 _move;


        private DPadDirection _currentDPadDirection = DPadDirection.None;
        public DPadDirection CurrentDPadDirection
        { 
            get => _currentDPadDirection;
        }

        public void Initialize(SideFighterControls gameplayControls,
            GameplayActionCommandInvoker invoker,
            ComboActionQueueManager queueManager)
        {
            _gameplayControls = gameplayControls;
            _invoker = invoker;
            _queueManager = queueManager;
        }

        public void Update()
        {
            _move = _gameplayControls.gameplay.move.ReadValue<Vector2>();
            HandleDPad();
        }

        // Checks for changes in DPad direction and processes them

        private void HandleDPad()
        {
            DPadDirection newDirection = DetermineDirectionFromInput(_move);
            ProcessDirectionChange(newDirection);
        }

        private DPadDirection DetermineDirectionFromInput(Vector2 moveInput)
        {
            if (_move.y > 0.5f) return DPadDirection.Up;
            if (_move.y < -0.5f) return DPadDirection.Down;
            if (_move.x > 0.5f) return DPadDirection.Right;
            if (_move.x < -0.5f) return DPadDirection.Left;

            return DPadDirection.None;
        }

        // Handles the change in direction by disabling the previous direction and enabling the new one.
        private void ProcessDirectionChange(DPadDirection newDirection)
        {
            if (_currentDPadDirection != newDirection)
            {
                _currentDPadDirection = newDirection;
                EnableCurrentDPadDirection();
            }
        }

        // Enables the visuals and command of new DPad direction
        private void EnableCurrentDPadDirection()
        {
            IGameplayActionCommand command = CreateDPadCommand();
            if (command != null)
            {
                _queueManager.AddCommandToComboSequence(command);
                _invoker.ExecuteCommand(command);
            }
        }

        // Create a command based on the current DPad direction
        private IGameplayActionCommand CreateDPadCommand()
        {
            // Switch expression from C# 8.0, 2019 
            return _currentDPadDirection switch
            {
                DPadDirection.Up => new DPadUpActionCommand(),
                DPadDirection.Down => new DPadDownActionCommand(),
                DPadDirection.Left => new DPadLeftActionCommand(),
                DPadDirection.Right => new DPadRightActionCommand(),
                _ => null
            };
        }
    }
}
