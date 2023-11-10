using UnityEngine;

namespace Tutorial.PatternCombo
{
    /// <summary>
    /// Listens for combo execution events and triggers the appropriate display commands.
    /// 
    /// This class functions as part of the ***Observer Pattern***, where it observes combo execution events
    /// and updates the game's display accordingly. It utilizes a factory to create display commands
    /// which encapsulate the logic for how these combos should be presented to the player.
    /// 
    /// While not a strict implementation of the Model-View-Presenter (MVP) pattern, this class 
    /// exhibits traits of a Presenter by observing changes (Model) and coordinating with 
    /// display logic (View), thus bridging the two with action-triggered updates.
    /// </summary>
    public class ComboDisplayCommandHandler : MonoBehaviour
    {
        [SerializeField]
        private ComboDisplayCommandFactory _comboDisplayCommandFactory;

        private void Awake()
        {
            // Subscribe to combo events to handle the display of combos when they are executed
            DashAttackComboEvent.OnDashAttackCombo += HandleDashAttackCombo;
            JumpKickComboEvent.OnJumpKickCombo += HandleJumpKickCombo;
        }

        private void OnDisable()
        {
            // Unsubscribe from combo events to prevent memory leaks or unintended behavior when the object is disabled
            DashAttackComboEvent.OnDashAttackCombo -= HandleDashAttackCombo;
            JumpKickComboEvent.OnJumpKickCombo -= HandleJumpKickCombo;
        }

        // Handle the display logic when a Dash Attack combo is executed
        private void HandleDashAttackCombo()
        {
            var comboDisplayCommand = _comboDisplayCommandFactory.CreateDashAttackDisplayCommand();
            ExecuteComboDisplayCommand(comboDisplayCommand);
        }

        private void HandleJumpKickCombo()
        {
            var comboDisplayCommand = _comboDisplayCommandFactory.CreateJumpKickDisplayCommand();
            ExecuteComboDisplayCommand(comboDisplayCommand);
        }

        // Execute the display command which updates the UI to show the combo has been performed
        private void ExecuteComboDisplayCommand(IGameplayDisplayCommand displayCommand)
        {
            displayCommand.ExecuteDisplay();
        }
    }
}
