using System.Collections.Generic;

public abstract class GameState
{
    private GameStateMachine _stateMachine;
    private List<CustomInput.GlobalActions> _requiredActions;
    
}