using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core {

  public class ActionScheduler : MonoBehaviour {

    private List<IAction> actions;
    private IAction currentAction;
    private void Start () {
      Debug.Log ("dfsldkfjsldkjflsdkmlskjmdflknm");
    }
    public void StartAction (IAction action) {
      if (currentAction != null && action.GetType () == currentAction.GetType ()) return;
      if (currentAction != null) {
        Debug.Log ("[ACTION SCHEDULER] Cancell action" + currentAction.GetType ());
        currentAction.Cancel ();
      }
      currentAction = action;
      currentAction.Start ();
      Debug.Log ("[ACTION SCHEDULER] Start action" + currentAction.GetType ());
    }
    public void CancelAction (IAction action) { }
    public void AddActionToQueue (IAction action) { }
    public void RemoveActionFromQueue (IAction action) { }

  }

}