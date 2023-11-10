using System;
using UnityEngine;

namespace Tutorial.PatternCombo
{
    /// <summary>
    /// Manages the display and state transitions of the DPad directional indicators in the UI.
    /// 
    /// It monitors the directional input from the DPadActionController and triggers visual updates
    /// via the GameplayDisplayCommandInvoker. This class effectively bridges the gap between
    /// user input and the visual feedback system, ensuring that changes in direction are
    /// reflected immediately and accurately on the screen.
    /// </summary>
    public class DPadDisplayController : MonoBehaviour
    {
        [SerializeField]
        private DPadDisplay _dPadUp, _dPadDown, _dPadLeft, _dPadRight;

        private GameplayDisplayCommandInvoker _invoker;
        private DPadActionController _dPadActionController;

        private DPadDirection _currentDPadDirection = DPadDirection.None;

        public void Initialize(DPadActionController dPadActionController,
            GameplayDisplayCommandInvoker invoker)
        {
            _invoker = invoker;
            _dPadActionController = dPadActionController;
        }

        public void Update()
        {
            HandleDPad();
        }

        // Checks for changes in DPad direction and processes them

        private void HandleDPad()
        {
            DPadDirection newDirection = _dPadActionController.CurrentDPadDirection;
            ProcessDirectionChange(newDirection);
        }

        // Handles the change in direction by disabling the previous direction and enabling the new one.
        private void ProcessDirectionChange(DPadDirection newDirection)
        {
            if (_currentDPadDirection != newDirection)
            {
                DisableCurrentDPadDirection();
                _currentDPadDirection = newDirection;
                ExecuteCurrentDPadDirectionDisplay();
            }
        }

        // Disables visuals of the current DPad direction
        private void DisableCurrentDPadDirection()
        {
            switch (_currentDPadDirection)
            {
                case DPadDirection.Up:
                    _dPadUp.ReleaseDPad();
                    break;
                case DPadDirection.Down:
                    _dPadDown.ReleaseDPad();
                    break;
                case DPadDirection.Left:
                    _dPadLeft.ReleaseDPad();
                    break;
                case DPadDirection.Right:
                    _dPadRight.ReleaseDPad();
                    break;
                case DPadDirection.None:
                    _dPadUp.ReleaseDPad();
                    _dPadDown.ReleaseDPad();
                    _dPadLeft.ReleaseDPad();
                    _dPadRight.ReleaseDPad();
                    break;
            }
        }

        // Enables the visuals and command of new DPad direction
        private void ExecuteCurrentDPadDirectionDisplay()
        {
            IGameplayDisplayCommand command = CreateDPadCommand();
            if (command != null)
            {
                _invoker.ExecuteCommand(command);
            }
        }

        // Create a command based on the current DPad direction
        private IGameplayDisplayCommand CreateDPadCommand()
        {
            // Switch expression from C# 8.0, 2019 
            return _currentDPadDirection switch
            {
                DPadDirection.Up => new DPadUpDisplayCommand(_dPadUp),
                DPadDirection.Down => new DPadDownDisplayCommand(_dPadDown),
                DPadDirection.Left => new DPadLeftDisplayCommand(_dPadLeft),
                DPadDirection.Right => new DPadRightDisplayCommand(_dPadRight),
                _ => null
            };
        }
    }
}
