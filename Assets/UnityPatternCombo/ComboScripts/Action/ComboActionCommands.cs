using UnityEngine;
using System;

namespace Tutorial.PatternCombo
{
    /// <summary>
    /// The action command for executing a dash attack combo.
    /// Utilizes the ***Observer Pattern*** to notify observers (e.g. ComboDisplayCommandHandler) when a combo is executed.
    /// </summary>
    public class DashAttackActionCommand : IGameplayActionCommand
    {
        public void ExecuteAction()
        {
            Debug.Log("Dash Attack Combo Executed");
            DashAttackComboEvent.Raise();
        }
    }

    /// <summary>
    /// Event class for dash attack combo. Used to notify when the dash attack combo is executed.
    /// </summary>
    public static class DashAttackComboEvent
    {
        public static event Action OnDashAttackCombo;

        public static void Raise()
        {
            OnDashAttackCombo?.Invoke();
        }
    }

    public class JumpKickActionCommand : IGameplayActionCommand
    {
        public void ExecuteAction()
        {
            Debug.Log("Jump-Kick Combo Executed");
            JumpKickComboEvent.Raise();
        }
    }

    public static class JumpKickComboEvent
    {
        public static Action OnJumpKickCombo;
        public static void Raise()
        {
            OnJumpKickCombo?.Invoke();
        }
    }
}