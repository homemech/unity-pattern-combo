using TMPro;
using UnityEngine;

namespace Tutorial.PatternCombo
{
    /// <summary>
    /// Factory class for creating combo commands.
    ///
    /// Using a factory here decouples the client code from the concrete classes,
    /// making it easier to add new types of combo commands in the future.
    /// </summary>
    public class ComboDisplayCommandFactory : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _displayTMP;

        public IGameplayDisplayCommand CreateDashAttackDisplayCommand()
        {
            return new DashAttackDisplayCommand(_displayTMP);
        }

        public IGameplayDisplayCommand CreateJumpKickDisplayCommand()
        {
            return new JumpKickDisplayCommand(_displayTMP);
        }
    }
}
