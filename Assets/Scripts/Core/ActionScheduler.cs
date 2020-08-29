using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core {

  public class ActionScheduler : MonoBehaviour {

    private List<MonoBehaviour> actions;
    private MonoBehaviour currentAction;
    private void Start () {
      Debug.Log ("dfsldkfjsldkjflsdkmlskjmdflknm");
    }
    public void StartAction (MonoBehaviour action) {
      if (currentAction != null && action.GetType () == currentAction.GetType ()) return;
      if (currentAction != null) Debug.Log ("[ACTION SCHEDULER] Cancell action" + currentAction.GetType ());
      currentAction = action;
      Debug.Log ("[ACTION SCHEDULER] Start action" + currentAction.GetType ());
      
    }
    public void CancelAction (MonoBehaviour action) { }
    public void AddActionToQueue (MonoBehaviour action) { }
    public void RemoveActionFromQueue (MonoBehaviour action) { }

  }

}