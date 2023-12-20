using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNpc : AnnouncementNPC
{       // 상점 NPC의 Class

    protected override void Awake()
    {
        base.Awake();
        AwakeInIt();
        ConvertionEventInIt();
    }       // Awake()


    private void Start()
    {
        GetCanvasScript_Obj();
        OnCanvasObj();

        ParamsInIt(npcID);
        NpcCanvas.NameUpdate(npcName);
        ChangeAnimationString(npcWaitMotion);
        OffCanvasObj();

    }       // Start()


    private void AwakeInIt()
    {
        npcID = (int)NPCID.Olive;

    }       // AwakeInIt()

    #region Base
    protected override void ParamsInIt(int _npcID)
    {
        base.ParamsInIt(_npcID);
    }       // ParamsInIt()

    protected override void GetCanvasScript_Obj()
    {
        base.GetCanvasScript_Obj();
    }       // GetCanvasScript_Obj()
    #endregion Base

    /// <summary>
    /// NPC 베이스 스크립트에 이벤트 구독
    /// </summary>
    private void ConvertionEventInIt()
    {
        StartConverationEvent += StartConvertion;
        NextConverationEvent += NextConveration;
        EndConverationEvent += EndConveration;

    }       // ConvertionEventInIt()

    /// <summary>
    /// 대화 시작
    /// </summary>
    protected override void StartConvertion()
    {
        OnCanvasObj();
        ChangeAnimationString(npcConversationMotion);
        base.PickConversationEvent(npcID);
    }       // StartConvertion()

    /// <summary>
    /// 다음 대사 출력할때 호출
    /// </summary>
    /// <param name="_nextConverationId">다음 대사의 ID</param>
    protected override void NextConveration(int _nextConverationId)
    {
        if (isCommunityDelray == false)
        {
            base.TitleInIt(_nextConverationId);
            NpcCanvas.TitleUpdate(npcTitle.ToString());
            DeQueueConversation();
        }
        else { /* PASS */ }
        //OutPutPickText(_nextConverationId);
    }       // NextConveration()

    /// <summary>
    /// 대사끝날때 호출
    /// </summary>
    protected override void EndConveration()
    {
        ChangeAnimationString(npcWaitMotion);
        base.EndConveration();
        OffCanvasObj();
    }       // EndConveration()




}       // ClassEnd
