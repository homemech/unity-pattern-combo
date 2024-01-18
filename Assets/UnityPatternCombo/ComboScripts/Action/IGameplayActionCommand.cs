
namespace Tutorial.PatternCombo
{
    /// <summary>
    /// Defines a contract for gameplay action commands, adhering to the ***Command Pattern.***
    /// 
    /// Implementing this interface allows the creation of concrete command classes that encapsulate all information
    /// needed to perform an action or trigger an event.
    /// 
    /// The interface ensures that any gameplay action, whether it's part of a combo or a standalone action,
    /// can be executed in a consistent manner, further allowing for easy extension and management of in-game actions.
    public interface IGameplayActionCommand
    {
        void ExecuteAction(); // Implement this method to execute the action.
    }
}
