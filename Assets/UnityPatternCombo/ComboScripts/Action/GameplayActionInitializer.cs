using System.Collections.Generic;
using UnityEngine;
namespace Tutorial.PatternCombo
{
    /// <summary>
    /// Sets up the entire gameplay action command system, translating player inputs into discrete game actions.
    /// It orchestrates the initialization of controllers and managers necessary for detecting and executing combos,
    /// following the ***Command pattern*** to encapsulate the actions such as moves, attacks, or special abilities.
    /// 
    /// 'Action' in this context encompasses all gameplay-related commands that result from player inputs.
    /// </summary>
    public class GameplayActionInitializer : MonoBehaviour
    {
        [SerializeField]
        private ButtonActionController _buttonActionController;

        // Using 'field:' to explicitly serialize the backing field of the property
        [field: SerializeField]
        public DPadActionController DPadActionController { get; private set; }

        [SerializeField]
        private ComboActionQueueManager _comboActionQueueManager;

        // Encapsulating the controls for a typical "side fighter game," providing a single point of reference
        public SideFighterControls GameplayControls { get; private set; }

        // Responsible for invoking the gameplay actions based on commands issued
        private GameplayActionCommandInvoker _actionCommandInvoker;

        public void Awake()
        {
            GameplayControls = new SideFighterControls();
            InitializeCommandInvoker();
            InitializeGameplayActionControllers();
        }

        private void InitializeCommandInvoker()
        {
            _actionCommandInvoker = new GameplayActionCommandInvoker();
        }
        
        // Initializes the action controllers that manage input-to-action translation and command handling
        private void InitializeGameplayActionControllers()
        {
            _buttonActionController.Initialize(GameplayControls, _actionCommandInvoker, _comboActionQueueManager);
            DPadActionController.Initialize(GameplayControls, _actionCommandInvoker, _comboActionQueueManager);
        }

        private void OnEnable()
        {
            GameplayControls.Enable();
        }

        private void OnDisable()
        {
            GameplayControls.Disable();
        }
    }
}
