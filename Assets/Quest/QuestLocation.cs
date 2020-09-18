using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLocation : MonoBehaviour
{
    // This code goes on a game object that represents the
    // task to be performed by the player at the location 
    // of the object. This code can contain any logic as long
    // as when the task is complete it injects the three statuses 
    // back into the Quest system (as per in the OnCollisionEnter)
    // currently here

    public QuestManager qManager;
    public QuestEvent qEvent;
    public QustButton qButton;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player") return;

        // if we shouldn't be working on this event
        // then don't register it as completed 
        if (qEvent.status != QuestEvent.EventStatus.CURRENT) return;

        // inject these back into the Quest Manager to Update States
        qEvent.UpdateQuestEvent(QuestEvent.EventStatus.DONE);
        qButton.UpdateButton(QuestEvent.EventStatus.DONE);
        qManager.UpdateQuestsOnCompletion(qEvent);
    }

    public void Setup(QuestManager qm, QuestEvent qe, QustButton qb)
    {
        qManager = qm;
        qEvent = qe;
        qButton = qb;

        // setup link between event and button
        qe.button = qButton;
    }

   
}
