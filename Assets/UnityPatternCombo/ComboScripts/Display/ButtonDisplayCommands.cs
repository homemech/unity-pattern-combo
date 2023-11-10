using UnityEngine;

namespace Tutorial.PatternCombo
{
    /// <summary>
    /// This script defines a set of classes that represent display commands for various gameplay buttons.
    /// 
    /// Each command class implements the IGameplayDisplayCommand and IButtonDisplayTransform interfaces, 
    /// encapsulating the visual feedback logic that corresponds to player input actions.
    ///
    /// The classes manage the display lifecycle of their associated button visualizations, such as activation, 
    /// deactivation, and resetting. This encapsulation allows for a modular and extensible system where new display 
    /// behaviors can be added with minimal impact on the existing system, adhering to the Open/Closed principle.
    /// 
    /// By utilizing a pooling system for efficient resource management, these commands contribute to a performant 
    /// visual representation of player actions, aiding both in-game feedback and debugging processes.
    /// </summary>
    public class DPadUpDisplayCommand : IGameplayDisplayCommand, IButtonDisplayTransform
    {
        private DPadDisplay _dPadDisplay;
        public Transform ButtonTransform => _dPadDisplay.transform;

        public DPadUpDisplayCommand(DPadDisplay dPadDisplay)
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

    public class DPadDownDisplayCommand : IGameplayDisplayCommand, IButtonDisplayTransform
    {
        private DPadDisplay _dPadDisplay;
        public Transform ButtonTransform => _dPadDisplay.transform;

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

    public class DPadLeftDisplayCommand : IGameplayDisplayCommand, IButtonDisplayTransform
    {
        private DPadDisplay _dPadDisplay;
        public Transform ButtonTransform => _dPadDisplay.transform;

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

    public class DPadRightDisplayCommand : IGameplayDisplayCommand, IButtonDisplayTransform
    {
        private DPadDisplay _dPadDisplay;
        public Transform ButtonTransform => _dPadDisplay.transform;

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

    public class XButtonDisplayCommand : IGameplayDisplayCommand, IButtonDisplayTransform
    {
        private ButtonDisplayPool _gameplayButtonDisplayPool;
        public Transform ButtonTransform { get; private set; }

        public XButtonDisplayCommand(ButtonDisplayPool gameplayButtonDisplayPool)
        {
            _gameplayButtonDisplayPool = gameplayButtonDisplayPool;
        }

        public void ExecuteDisplay()
        {
            var buttonDisplay = _gameplayButtonDisplayPool.GetPooledButtonDisplay();
            var color = _gameplayButtonDisplayPool.ButtonDisplaySettings.XButtonColor;
            ButtonTransform = buttonDisplay.transform;
            buttonDisplay.Setup("X", color, _gameplayButtonDisplayPool);
            buttonDisplay.gameObject.SetActive(true);
        }
    }

    public class YButtonDisplayCommand : IGameplayDisplayCommand, IButtonDisplayTransform
    {
        private ButtonDisplayPool _gameplayButtonDisplayPool;
        public Transform ButtonTransform { get; private set; }

        public YButtonDisplayCommand(ButtonDisplayPool gameplayButtonDisplayPool)
        {
            _gameplayButtonDisplayPool = gameplayButtonDisplayPool;
        }

        public void ExecuteDisplay()
        {
            var buttonDisplay = _gameplayButtonDisplayPool.GetPooledButtonDisplay();
            var color = _gameplayButtonDisplayPool.ButtonDisplaySettings.YButtonColor;
            ButtonTransform = buttonDisplay.transform;
            buttonDisplay.Setup("Y", color, _gameplayButtonDisplayPool);
            buttonDisplay.gameObject.SetActive(true);
        }
    }

    public class AButtonDisplayCommand : IGameplayDisplayCommand, IButtonDisplayTransform
    {
        private ButtonDisplayPool _gameplayButtonDisplayPool;
        public Transform ButtonTransform { get; private set; }

        public AButtonDisplayCommand(ButtonDisplayPool gameplayButtonDisplayPool)
        {
            _gameplayButtonDisplayPool = gameplayButtonDisplayPool;
        }

        public void ExecuteDisplay()
        {
            var buttonDisplay = _gameplayButtonDisplayPool.GetPooledButtonDisplay();
            var color = _gameplayButtonDisplayPool.ButtonDisplaySettings.AButtonColor;
            ButtonTransform = buttonDisplay.transform;
            buttonDisplay.Setup("A", color, _gameplayButtonDisplayPool);
            buttonDisplay.gameObject.SetActive(true);
        }
    }

    public class BButtonDisplayCommand : IGameplayDisplayCommand, IButtonDisplayTransform
    {
        private ButtonDisplayPool _gameplayButtonDisplayPool;
        public Transform ButtonTransform { get; private set; }

        public BButtonDisplayCommand(ButtonDisplayPool gameplayButtonDisplayPool)
        {
            _gameplayButtonDisplayPool = gameplayButtonDisplayPool;
        }

        public void ExecuteDisplay()
        {
            var buttonDisplay = _gameplayButtonDisplayPool.GetPooledButtonDisplay();
            var color = _gameplayButtonDisplayPool.ButtonDisplaySettings.BButtonColor;
            ButtonTransform = buttonDisplay.transform;
            buttonDisplay.Setup("B", color, _gameplayButtonDisplayPool);
            buttonDisplay.gameObject.SetActive(true);
        }
    }
}
