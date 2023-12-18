using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Js.Quest
{
    // [완료가능] 상태
    public class CanComplete : IState
    {
        /*************************************************
         *                 Public Methods
         *************************************************/
        // 현재 상태를 출력
        public void PrintCurrentState()
        {
            GFunc.Log("현재 상태: [완료가능]");
        }

        // 다음 상태로 변경(시작불가 -> 시작가능 -> 진행중 -> 완료 가능 -> 완료)
        public void ChangeToNextState(Quest quest)
        {
            // 현재 상태가 [완료가능]일 경우
            if (quest.QuestState.State.Equals(QuestState.StateQuest.CAN_COMPLETE))
            {
                // [완료]으로 상태 변경
                quest.QuestState.ChangeState(QuestState.StateQuest.COMPLETED);
            }
        }
    }
}
