using UnityEngine;

namespace Tutorial.PatternCombo
{
    /// <summary>
    /// The ButtonDisplayController manages the visual representation of gameplay button interactions.
    /// 
    /// It observes player inputs and triggers display commands to provide visual feedback for each button press.
    /// 
    /// This visual feedback aids in visualizing input sequences. By utilizing the
    /// Command pattern, this class encapsulates the display logic into commands, which are then executed by
    /// a display command invoker, thus separating the input handling from the visual representation logic.
    /// </summary>
    public class ButtonDisplayController : MonoBehaviour
    {
        [SerializeField]
        private ButtonDisplayPool _gameplayButtonDisplayPool;

        private SideFighterControls _gameplayControls;
        private GameplayDisplayCommandInvoker _displayInvoker;

        public void Initialize(SideFighterControls gameplayControls, GameplayDisplayCommandInvoker invoker)
        {
            _gameplayControls = gameplayControls;
            _displayInvoker = invoker;
            SetupActions();
        }

        private void SetupActions()
        {
            _gameplayControls.gameplay.x.performed += ctx =>
            {
                HandleXButtonDisplayCommand();
            };

            _gameplayControls.gameplay.y.performed += ctx =>
            {
                HandleYButtonDisplayCommand(); 
            };

            _gameplayControls.gameplay.a.performed += ctx =>
            {
                HandleAButtonDisplayCommand();
            };

            _gameplayControls.gameplay.b.performed += ctx =>
            {
                HandleBButtonDisplayCommand();
            };
        }
        private void HandleXButtonDisplayCommand()
        {
            var xButtonCommand = new XButtonDisplayCommand(_gameplayButtonDisplayPool);
            ExecuteDisplayCommand(xButtonCommand);
        }
    
        private void HandleYButtonDisplayCommand()
        {
            var yButtonCommand = new YButtonDisplayCommand(_gameplayButtonDisplayPool);
            ExecuteDisplayCommand(yButtonCommand);
        }
    
        private void HandleAButtonDisplayCommand()
        {
            var aButtonCommand = new AButtonDisplayCommand(_gameplayButtonDisplayPool);
            ExecuteDisplayCommand(aButtonCommand);
        }
    
        private void HandleBButtonDisplayCommand()
        {
            var bButtonCommand = new BButtonDisplayCommand(_gameplayButtonDisplayPool);
            ExecuteDisplayCommand(bButtonCommand);
        }
    
        private void ExecuteDisplayCommand(IGameplayDisplayCommand command)
        {
            _displayInvoker.ExecuteCommand(command);
        }
    }
}
