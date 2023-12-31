using System;
using System.Text;
using System.Collections;
using UnityEngine;
using Js.Quest;

public static class GFunc
{
    /*************************************************
     *               Private Fields
     *************************************************/
    private static StringBuilder stringBuilder = new StringBuilder();


    /*************************************************
     *               Public Methods
     *************************************************/
    // Legacy:
    //public static string SumString(string inputA, string inputB, string inputC = "", string inputD = "")
    //{
    //    stringBuilder.Clear();
    //    stringBuilder.Append(inputA);
    //    stringBuilder.Append(inputB);
    //    stringBuilder.Append(inputC);
    //    stringBuilder.Append(inputD);

    //    return stringBuilder.ToString();
    //}

    /// <summary>
    /// 매개 변수로 받은 모든 string 인자를 더해서 반환한다.
    /// </summary>
    public static string SumString(params string[] inputs)
    {
        stringBuilder.Clear();
        for (int i = 0; i < inputs.Length; i++)
        {
            stringBuilder.Append(inputs[i]);
        }

        return stringBuilder.ToString();
    }

    // 언더바를 없애주는 String 확장 메서드
    public static string RemoveUnderbar(this string input)
    {
        return input.Replace("_", "");
    }

    /// <summary>
    /// 늘어져있는 대사의 Replace와 Split이후 반환해주는 함수
    /// </summary>    
    /// <param name="_placeString">GetData해온 string값</param>
    /// <returns></returns>
    public static string[] SplitConversation(string _placeString)
    {
        _placeString = _placeString.Replace("\\n", "\n");
        _placeString = _placeString.Replace("#", ",");
        _placeString = _placeString.Replace("\\", "");
        _placeString = _placeString.Replace("_", "");

        string[] replaceStrings = _placeString.Split("\n");

        //tableIDs = tableIDs.Replace("\\n", "\n");
        //tableIDs = tableIDs.Replace("\\", "");        


        return replaceStrings;
    }       // SplitConveration()

    /// <summary>
    /// GetData해온 string값을 Replace와 Split한후 int[]로 변환시켜줘서 반환해주는 함수
    /// </summary>
    /// <param name="_parsString">Id값이 들어있는 string</param>
    /// <returns>int[] 반환</returns>
    public static int[] SplitIds(string _parsString)
    {
        _parsString = _parsString.Replace("\\\\n", "\n");
        _parsString = _parsString.Replace("\\n", "\n");
        _parsString = _parsString.Replace("#", ",");
        _parsString = _parsString.Replace("\\", "");
        _parsString = _parsString.Replace("_", "");
        string[] splitParams = _parsString.Split("\n");

        int[] splitIds = new int[splitParams.Length];
        for (int i = 0; i < splitParams.Length; i++)
        {
            splitIds[i] = int.Parse(splitParams[i]);
        }

        return splitIds;
    }       // SplitIds()

    /// <summary>
    /// GetData해온 string값을 Replace와 Split한후 float[]로 변환시켜줘서 반환해주는 함수
    /// </summary>
    /// <param name="_parsString">Id값이 들어있는 string</param>
    /// <returns>int[] 반환</returns>
    public static float[] SplitFloats(string _parsString)
    {
        _parsString = _parsString.Replace("\\n", "\n");
        _parsString = _parsString.Replace("#", ",");
        _parsString = _parsString.Replace("\\", "");
        _parsString = _parsString.Replace("_", "");
        string[] splitParams = _parsString.Split("\n");

        for (int i = 0; i < splitParams.Length; i++)
        {
            GFunc.Log($"splitParms 값 {splitParams[i]}");
        }
        float[] splitFloat = new float[splitParams.Length];
        for (int i = 0; i < splitParams.Length; i++)
        {
            splitFloat[i] = float.Parse(splitParams[i]);
        }

        return splitFloat;
    }       // SplitFloats()

    /*************************************************
     *                    Debug
     *************************************************/
    #region Debug
    // 디버그 로그를 찍어주는 메서드
    public static void Log(string _input)
    {
#if UNITY_EDITOR
        Debug.Log(_input);
#endif
    }

    // 디버그 로그를 찍어주는 메서드
    public static void Log(object _input)
    {
#if UNITY_EDITOR
        Debug.Log(_input);
#endif
    }

    // 디버그 로그를 찍어주는 메서드
    public static void LogWarning(string _input)
    {
#if UNITY_EDITOR

        Debug.LogWarning(_input);
#endif
    }

    // 디버그 로그를 찍어주는 메서드
    public static void LogError(string _input)
    {
#if UNITY_EDITOR
        Debug.LogError(_input);
#endif
    }
    // 디버그 로그를 찍어주는 메서드
    public static void LogErrorFormat(string _input)
    {
#if UNITY_EDITOR
        Debug.LogErrorFormat(_input);
#endif
    }

    // 디버그 로그를 찍어주는 메서드
    public static void LogException(System.Exception _input)
    {
#if UNITY_EDITOR
        Debug.LogException(_input);
#endif
    }
    #endregion

    // 강제로 진행중으로 변경하는 메서드
    public static void DebugQuestInProgress(int id)
    {
        Quest quest = UserDataManager.QuestDictionary[id];
        quest.ChangeState(3);
    }

    // NPC 대화의 이벤트를 실행시켜주는 함수
    public static void ChoiceEvent(int targetID)
    {
        string eventID = Data.GetString(targetID, "Choice1Event");
        Log(eventID + "이벤트 ID");
        int[] ids = SplitIds(eventID);

        for (int i = 0; i < ids.Length; i++)
        {
            if (ids[i] == 0)
            { break; }
            Unit.InProgressQuestByID(ids[i]);
            Log(ids[i] + " 진행중으로 변경");
        }
    }


}   // ClassEnd
