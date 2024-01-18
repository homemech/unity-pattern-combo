using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial.PatternCombo
{
    /// <summary>
    /// Initializes and coordinates the display command system, ensuring player inputs are visually represented in the game interface.
    /// The system handles the synchronization of visual cues with the action command system through a decoupled command pattern.
    /// 
    /// 'Display' refers to the visual log or input visualizer of gameplay action commands.
    /// </summary>
    public class ButtonDisplayInitializer : MonoBehaviour
    {
        [SerializeField]
        private GameplayActionInitializer _gameplayActionInitializer;
        [SerializeField]
        private ButtonDisplayController _buttonDisplayController;
        [SerializeField]
        private DPadDisplayController _dPadDisplayController;

        private SideFighterControls _gameplayControls;
        private GameplayDisplayCommandInvoker _invoker;

        public void Awake()
        {
            InitializeInvoker();
        }

        private void InitializeInvoker()
        {
            _invoker = new GameplayDisplayCommandInvoker();
        }

        private void Start()
        {
            InitializeGameplayDisplayControllers();
        }

        private void InitializeGameplayDisplayControllers()
        {
            _gameplayControls = _gameplayActionInitializer.GameplayControls;
            _buttonDisplayController.Initialize(_gameplayControls, _invoker);
            _dPadDisplayController.Initialize(_gameplayActionInitializer.DPadActionController, _invoker);
        }
    }
}
