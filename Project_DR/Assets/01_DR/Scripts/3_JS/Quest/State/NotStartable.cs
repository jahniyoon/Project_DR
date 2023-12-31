using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Js.Quest
{
    // [시작불가] 상태
    public class NotStartable : IState
    {
        /*************************************************
         *                 Public Methods
         *************************************************/
        // 현재 상태를 출력
        public void PrintCurrentState()
        {
            GFunc.Log("현재 상태: [시작불가]");
        }

        // 다음 상태로 변경 {[시작불가] -> [시작가능] -> [진행중] -> [완료가능] -> [완료]}
        public void ChangeToNextState(Quest quest, QuestState questState)
        {
            // 선행 퀘스트가 있을 경우
            int requiredQuestID = quest.QuestData.RequiredQuestID;
            if (requiredQuestID.Equals(0).Equals(false))
            {
                // 선행 퀘스트의 상태가 [완료]일 경우
                if (UserDataManager.QuestDictionary[requiredQuestID].
                    QuestState.State.Equals(QuestState.StateQuest.COMPLETED))
                {
                    // 디버그
                    GFunc.Log($"선행퀘스트: {quest.QuestData.RequiredQuestID}, 상태: {quest.QuestState}");

                    // 일치할 경우 [시작가능]으로 상태 변경
                    questState.ChangeState(QuestState.StateQuest.CAN_STARTABLE);
                }
            }

            // 선행 퀘스트가 없을 경우
            else
            {
                // [시작가능]으로 상태 변경
                questState.ChangeState(QuestState.StateQuest.CAN_STARTABLE);
            }
        }
    }
}
