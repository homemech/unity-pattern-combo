using UnityEngine;

namespace Tutorial.PatternCombo
{
    /// <summary>
    /// This script defines a set of classes that represent display commands for various gameplay buttons.
    /// 
    /// The classes manage the display lifecycle of their associated button visualizations, such as activation, 
    /// deactivation, and resetting. This encapsulation allows for a modular and extensible system where new display 
    /// behaviors can be added with minimal impact on the existing system, adhering to the Open/Closed principle.
    /// 
    /// Buttons (but not D-Pad) utilize a pooling system for efficient resource management. 
    /// </summary>
    public class DPadUpDisplayCommand : IGameplayDisplayCommand
    {
        // Reference to the DPad display that this command will act upon.
        private DPadDisplay _dPadDisplay;

        // Constructor to initialize the command with a specific DPad display.
        public DPadUpDisplayCommand(DPadDisplay dPadDisplay)
        {
            _dPadDisplay = dPadDisplay;
        }

        // Executes the display logic for the DPad up direction. 
        // If the DPad display is not active, it activates it. Otherwise, it resets the display.
        public void ExecuteDisplay()
        {
            if (!_dPadDisplay.gameObject.activeInHierarchy)
            {
                _dPadDisplay.gameObject.SetActive(true);
                return;
            }
            _dPadDisplay.Reset();
        }
    }

    public class DPadDownDisplayCommand : IGameplayDisplayCommand
    {
        private DPadDisplay _dPadDisplay;

        public DPadDownDisplayCommand(DPadDisplay dPadDisplay)
        {
            _dPadDisplay = dPadDisplay;
        }

        public void ExecuteDisplay()
        {
            if (!_dPadDisplay.gameObject.activeInHierarchy)
            {
                _dPadDisplay.gameObject.SetActive(true);
                return;
            }
            _dPadDisplay.Reset();
        }
    }

    public class DPadLeftDisplayCommand : IGameplayDisplayCommand
    {
        private DPadDisplay _dPadDisplay;

        public DPadLeftDisplayCommand(DPadDisplay dPadDisplay)
        {
            _dPadDisplay = dPadDisplay;
        }
        public void ExecuteDisplay()
        {
            if (!_dPadDisplay.gameObject.activeInHierarchy)
            {
                _dPadDisplay.gameObject.SetActive(true);
                return;
            }
            _dPadDisplay.Reset();
        }
    }

    public class DPadRightDisplayCommand : IGameplayDisplayCommand
    {
        private DPadDisplay _dPadDisplay;

        public DPadRightDisplayCommand(DPadDisplay dPadDisplay)
        {
            _dPadDisplay = dPadDisplay;
        }

        public void ExecuteDisplay()
        {
            if (!_dPadDisplay.gameObject.activeInHierarchy)
            {
                _dPadDisplay.gameObject.SetActive(true);
                return;
            }
            _dPadDisplay.Reset();
        }
    }

    public class XButtonDisplayCommand : IGameplayDisplayCommand
    {
        // This pool manages the recycling of ButtonDisplay objects to optimize performance.
        private ButtonDisplayPool _gameplayButtonDisplayPool;

        // Constructor to initialize the command with a reference to the ButtonDisplayPool.
        public XButtonDisplayCommand(ButtonDisplayPool gameplayButtonDisplayPool)
        {
            _gameplayButtonDisplayPool = gameplayButtonDisplayPool;
        }

        // Executes the display logic for the X button, utilizing an object pool for efficient resource management.
        public void ExecuteDisplay()
        {
            // Retrieve a ButtonDisplay object from the pool to minimize instantiation overhead.
            var buttonDisplay = _gameplayButtonDisplayPool.GetPooledButtonDisplay();
            
            // Acquire the designated color for the X button from the settings object.
            var color = _gameplayButtonDisplayPool.ButtonDisplaySettings.XButtonColor;

            // Set up the button display with the appropriate label and color, and make it active in the scene.
            buttonDisplay.Setup("X", color, _gameplayButtonDisplayPool);
            buttonDisplay.gameObject.SetActive(true);
        }
    }

    public class YButtonDisplayCommand : IGameplayDisplayCommand
    {
        private ButtonDisplayPool _gameplayButtonDisplayPool;

        public YButtonDisplayCommand(ButtonDisplayPool gameplayButtonDisplayPool)
        {
            _gameplayButtonDisplayPool = gameplayButtonDisplayPool;
        }

        public void ExecuteDisplay()
        {
            var buttonDisplay = _gameplayButtonDisplayPool.GetPooledButtonDisplay();
            var color = _gameplayButtonDisplayPool.ButtonDisplaySettings.YButtonColor;
            buttonDisplay.Setup("Y", color, _gameplayButtonDisplayPool);
            buttonDisplay.gameObject.SetActive(true);
        }
    }

    public class AButtonDisplayCommand : IGameplayDisplayCommand
    {
        private ButtonDisplayPool _gameplayButtonDisplayPool;

        public AButtonDisplayCommand(ButtonDisplayPool gameplayButtonDisplayPool)
        {
            _gameplayButtonDisplayPool = gameplayButtonDisplayPool;
        }

        public void ExecuteDisplay()
        {
            var buttonDisplay = _gameplayButtonDisplayPool.GetPooledButtonDisplay();
            var color = _gameplayButtonDisplayPool.ButtonDisplaySettings.AButtonColor;
            buttonDisplay.Setup("A", color, _gameplayButtonDisplayPool);
            buttonDisplay.gameObject.SetActive(true);
        }
    }

    public class BButtonDisplayCommand : IGameplayDisplayCommand
    {
        private ButtonDisplayPool _gameplayButtonDisplayPool;

        public BButtonDisplayCommand(ButtonDisplayPool gameplayButtonDisplayPool)
        {
            _gameplayButtonDisplayPool = gameplayButtonDisplayPool;
        }

        public void ExecuteDisplay()
        {
            var buttonDisplay = _gameplayButtonDisplayPool.GetPooledButtonDisplay();
            var color = _gameplayButtonDisplayPool.ButtonDisplaySettings.BButtonColor;
            buttonDisplay.Setup("B", color, _gameplayButtonDisplayPool);
            buttonDisplay.gameObject.SetActive(true);
        }
    }
}
