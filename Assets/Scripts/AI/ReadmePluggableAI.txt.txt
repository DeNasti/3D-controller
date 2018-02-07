The whole AI is based on the pluggable AI from Unity (a tutorial on their youtube channel).

It's a state machine based AI.

The core of the AI is the StateController, which on "void Update" make the current state update itself.

The State class do all the actions of his state and then check what transition to do (the transition could even be
to dont change state).

every AbstractAction is something the AI will do (attack, follow the player, patroll ecc)

A transition is made of a decision and of 2 states: the "trueState" and "falseState"
The function "decision.Decide()" returns a bool that has to be used to evaluate wich state choose between "trueState"
or "falseState", then the state controller will change is current state in the one choosed.