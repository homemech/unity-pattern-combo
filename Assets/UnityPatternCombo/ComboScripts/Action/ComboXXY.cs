using System.Collections.Generic;
using System.Linq;
namespace Tutorial.PatternCombo
{
    public class ComboXXY : IComboRule
    {
        private ComboActionCommandFactory _comboActionCommandFactory;

        public int ComboLength { get; private set; }

        public ComboXXY(ComboActionCommandFactory actionCommandFactory)
        {
            _comboActionCommandFactory = actionCommandFactory;
            ComboLength = 3;
        }

        public bool IsFirstConditionMet(IGameplayActionCommand firstCommand)
        {
            return firstCommand is XButtonActionCommand;
        }

        public bool IsMatch(IEnumerable<IGameplayActionCommand> sequence)
        {
            var sequenceArray = sequence.Take(ComboLength).ToArray();

            if (sequenceArray.Length < ComboLength)
            {
                return false;
            }

            var first = sequenceArray[0];
            var second = sequenceArray[1];
            var third = sequenceArray[2];

            return first is XButtonActionCommand && second is XButtonActionCommand && third is YButtonActionCommand;
        }

        public IGameplayActionCommand GetResultingComboCommand()
        {
            return _comboActionCommandFactory.CreateDashAttackCommand();
        }
    }
}
