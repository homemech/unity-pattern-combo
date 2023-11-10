using TMPro;

namespace Tutorial.PatternCombo
{
    public class DashAttackDisplayCommand : IGameplayDisplayCommand
    {
        private TextMeshProUGUI _comboTMP;
        public DashAttackDisplayCommand(TextMeshProUGUI comboTMP)
        {
            _comboTMP = comboTMP;
        }

        public void ExecuteDisplay()
        {
            _comboTMP.SetText("DASH ATTACK!");
        }
    }

    public class JumpKickDisplayCommand : IGameplayDisplayCommand
    {
        private TextMeshProUGUI _comboTMP;
        public JumpKickDisplayCommand(TextMeshProUGUI comboTMP)
        {
            _comboTMP = comboTMP;
        }
        public void ExecuteDisplay()
        {
            _comboTMP.SetText("JUMP KICK!");
        }
    }
}