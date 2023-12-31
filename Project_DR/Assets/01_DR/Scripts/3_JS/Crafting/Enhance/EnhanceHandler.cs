using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Js.Crafting
{
    public class MBTIValue
    {
        public float i;
        public float n;
        public float f;
        public float p;
    }

    public class EnhanceHandler : ICraftingComponent
    {
        /*************************************************
         *                 Public Fields
         *************************************************/
        public int StatID => _statID;                               // 스텟 ID
        public int[] StatAmounts => _statAmounts;                   // 스텟 증가량[]
        public int[] SuccessProbability => _successProbabilities;   // 성공 확률[]
        public MBTIValue[] MBTIValue => _mbtiValues;                // MBTI 수치[]
        public const int TABLE_INDEX = 3_4000_1;                    // 테이블 색인 인덱스


        /*************************************************
         *                 Private Fields
         *************************************************/
        private int _statID;
        private int[] _statAmounts;
        private int[] _successProbabilities;
        private MBTIValue[] _mbtiValues;


        /*************************************************
         *               Initialize Methods
         *************************************************/
        public EnhanceHandler(int statID)
        {
            // Init
            _statID = statID;
            List<int> idTable = DataManager.Instance.GetDataTableIDs(TABLE_INDEX);
            int count = idTable.Count;
            _statAmounts = new int[count];
            _successProbabilities = new int[count];
            _mbtiValues = new MBTIValue[count];
            for (int i = 0; i < count; i++)
            {
                int id = idTable[i];
                MBTIValue mbtiValue = new MBTIValue();
                mbtiValue.i = Data.GetFloat(id, "MBTI_Value_I");
                mbtiValue.n = Data.GetFloat(id, "MBTI_Value_N");
                mbtiValue.f = Data.GetFloat(id, "MBTI_Value_F");
                mbtiValue.p = Data.GetFloat(id, "MBTI_Value_P");
                _statAmounts[i] = Data.GetInt(id, "Stat_Amount");
                _successProbabilities[i] = Data.GetInt(id, "Success_Probability");
                _mbtiValues[i] = mbtiValue;
            }
        }


        /*************************************************
         *                 Public Methods
         *************************************************/
        public bool CheckCraft()
        {
            // 조건이 없으므로 true 반환
            return true;
        }

        public bool CheckEnhance()
        {
            // 조건이 없으므로 true 반환
            return true;
        }

        public void Craft() { }

        // 강화 시도
        public void Enhance(int type)
        {
            // 강화 성공시
            if (GetRandomProbability(_successProbabilities[type]))
            {
                //TODO 강화 능력치 추가
                GFunc.Log($"[{type}] 강화 성공! 확률[{_successProbabilities[type]}] ");
                //UserData.ActiveSkill(_statID, _statAmounts[type]);
            }
        }

        /*************************************************
         *                Private Methods
         *************************************************/
        // 랜덤 확률 돌리기
        // [true = 성공] / [false = 실패]
        private bool GetRandomProbability(int probability)
        {
            int randomprobability = Random.Range(0, 101);
            if (randomprobability <= probability)
            {
                // 성공할 경우
                return true;
            }

            // 실패할 경우
            return false;
        }
    }
}
