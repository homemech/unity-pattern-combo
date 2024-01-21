using System.Collections.Generic;
using System.Linq;
namespace Tutorial.PatternCombo
{
    /// <summary>
    /// Implements a combo rule that matches a specific sequence of commands for a "Up+B" combo.
    /// 
    /// This class is part of the Strategy Pattern implementation for combo detection.
    /// By conforming to the IComboRule interface, it can be easily swapped with other rules,
    /// allowing for a flexible and expandable combo system.
    /// </summary>
    public class ComboUpB : IComboRule
    {
        private ComboActionCommandFactory _comboActionCommandFactory;

        public int ComboLength { get; private set; }

        public ComboUpB(ComboActionCommandFactory actionCommandFactory)
        {
            _comboActionCommandFactory = actionCommandFactory;
            ComboLength = 2;
        }

        public bool IsFirstConditionMet(IGameplayActionCommand firstCommand)
        {
            return firstCommand is DPadUpActionCommand;
        }

        public bool IsMatch(IEnumerable<IGameplayActionCommand> sequence)
        {
            // Convert the sequence to an array to facilitate direct indexing.
            // Materialize only the part of the sequence needed for this rule.
            var sequenceArray = sequence.Take(ComboLength).ToArray();

            // Early exit if the sequence is shorter than the number of commands in the combo.
            if (sequenceArray.Length < ComboLength)
            {
                return false;
            }

            // Assigning to local variables for clarity and to improve readability.
            var first = sequenceArray[0];
            var second = sequenceArray[1];

            // The combo is valid if the first command is Up and the second is B.
            return first is DPadUpActionCommand && second is BButtonActionCommand;
        }

        /// <summary>
        /// Produces the combo action command associated with the "Up+B" pattern.
        /// </summary>
        /// <returns>A new instance of a JumpKickActionCommand.</returns>
        public IGameplayActionCommand GetResultingComboCommand()
        {
            return _comboActionCommandFactory.CreateJumpKickCommand();
        }
    }
}


