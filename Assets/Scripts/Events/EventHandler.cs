public delegate void MovementDelegate(float inputX, float inputY, bool isWalking,
                                      bool isRunning, bool isIdle, bool isCarrying,
                                      ToolEffect tooEffect,
                                      bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
                                      bool isLiftingToolRight, bool isLifingToolLeft, bool isLiftingRollUp, bool isLiftingToolDown,
                                      bool isPickingToolRight, bool isPickingToolLeft, bool isPickingRollUp, bool isPickingToolDown,
                                      bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingRollUp, bool isSwingingToolDown,
                                      bool idleRight, bool idleLeft, bool idlelUp, bool idleDown);
                                      
public static class EventHandler {
    // Movement event for subscribers
    public static event MovementDelegate MovementEvent;
    
    // Movement event for publishers
    public static void CallMovementEvent(float inputX, float inputY, bool isWalking,
                                         bool isRunning, bool isIdle, bool isCarrying,
                                         ToolEffect tooEffect,
                                         bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
                                         bool isLiftingToolRight, bool isLifingToolLeft, bool isLiftingRollUp, bool isLiftingToolDown,
                                         bool isPickingToolRight, bool isPickingToolLeft, bool isPickingRollUp, bool isPickingToolDown,
                                         bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingRollUp, bool isSwingingToolDown,
                                         bool idleRight, bool idleLeft, bool idlelUp, bool idleDown) {
        if (MovementEvent != null) {
            MovementEvent(inputX,
                          inputY,
                          isWalking,
                          isRunning,
                          isIdle,
                          isCarrying,
                          tooEffect,
                          isUsingToolRight,
                          isUsingToolLeft,
                          isUsingToolUp,
                          isUsingToolDown,
                          isLiftingToolRight,
                          isLifingToolLeft,
                          isLiftingRollUp,
                          isLiftingToolDown,
                          isPickingToolRight,
                          isPickingToolLeft,
                          isPickingRollUp,
                          isPickingToolDown,
                          isSwingingToolRight,
                          isSwingingToolLeft,
                          isSwingingRollUp,
                          isSwingingToolDown,
                          idleRight,
                          idleLeft,
                          idlelUp,
                          idleDown);
        }
    }
}
