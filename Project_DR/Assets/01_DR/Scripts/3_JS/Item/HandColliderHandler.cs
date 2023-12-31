using System;
using System.Collections;
using UnityEngine;
using BNG;

public class HandColliderHandler : MonoBehaviour
{
    ///*************************************************
    // *                 Private Methods
    // *************************************************/
    //#region [+]
    //private enum State
    //{
    //    Default = 0,
    //    ProcessingOne,
    //    ProcessingTwo
    //}
    //[SerializeField] private State _state;

    //private Rigidbody rigidBody = default;
    //private ItemColliderHandler latestGripItem = default;
    //private float chanageKinematicDelay = 3f;   // 물리 효과 종료 딜레이

    //#endregion
    ///*************************************************
    // *                 Unity Events
    // *************************************************/
    //#region [+]
    //void Start()
    //{
    //    rigidBody = GetComponent<Rigidbody>();
    //}

    ////private void Update()
    ////{
    ////    if (latestGripItem != null)
    ////    {
    ////        if (latestGripItem.GrabbableHaptics.CurrentGrabber == null)
    ////        {
    ////            GFunc.Log("Grip Off Item");

    ////            // 5초 후에 수납 가능 상태로 변경
    ////            latestGripItem.Coroutine(latestGripItem.ResetState, 5f);

    ////            // 리셋
    ////            latestGripItem = default;
    ////        }
    ////    }
    ////}

    //private void OnTriggerEnter(Collider other)
    //{
    //    // 감지된 콜라이더가 아이템 슬롯일 경우 & hand 상태가 기본일 경우
    //    if (other.CompareTag("ItemSlot") && _state == State.Default)
    //    {
    //        ItemSlotController itemSlot = other.GetComponent<ItemSlotController>();
    //        // 수납 가능한 경우에만 수납함
    //        if (itemSlot.IsStorageAvailable)
    //        {
    //            GFunc.Log("수납");
    //            // 콜라이더가 인벤토리 스크롤 패널 안에 있을 경우
    //            if (CheckColliderVisibility(
    //                other.transform.parent.parent.parent.parent.parent.parent.GetComponent<RectTransform>(),
    //                other.GetComponent<RectTransform>()) == true)
    //            {
    //                GFunc.Log($"name: {other.transform.parent.name}");

    //                // 상태 변경
    //                _state = State.ProcessingOne;
    //            }
    //            else
    //            {
    //                GFunc.Log("Out of range");
    //            }
    //        }
    //    }
    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    // 현재 작업 상태일 경우
    //    if (other.CompareTag("ItemSlot") && _state == State.ProcessingOne)
    //    {
    //        // 왼쪽 컨트롤러에서 트리거 키를 눌렀을 경우
    //        if (global::BNG.InputBridge.Instance.LeftTriggerDown)
    //        {
    //            // 상태 변경
    //            _state = State.ProcessingTwo;

    //            // 디버그
    //            GFunc.Log("Left Trigger Pressed");

    //            GripItem(other);
    //        }

    //        // 오른쪽 컨트롤러에서 트리거 키를 눌렀을 경우
    //        if (global::BNG.InputBridge.Instance.RightTriggerDown)
    //        {
    //            // 상태 변경
    //            _state = State.ProcessingTwo;

    //            // 디버그
    //            GFunc.Log("Right Trigger Pressed");

    //            GripItem(other);
    //        }

    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    //ChangeStateCoroutine(State.Default, 1f);
    //    if (_state == State.ProcessingOne || _state == State.ProcessingTwo)
    //    {
    //        // 상태 변경
    //        _state = State.Default;
    //    }
    //}

    //#endregion
    ///*************************************************
    //*                 Private Methods
    //*************************************************/
    //#region [+]
    //private void GripItem(Collider other)
    //{
    //    Transform slot = other.transform.parent;
    //    GameObject item = ItemManager.instance.CreateItem(Vector3.zero, 5001);
    //    ItemColliderHandler itemColliderHandler = item.GetComponent<ItemColliderHandler>();

    //    // 슬롯에 넣을 수 없도록 아이템 상태 Stop으로 변경
    //    itemColliderHandler.state = ItemColliderHandler.State.Stop;

    //    // 아이템 물리 효과 정지
    //    itemColliderHandler.ChangeKinematic(true);

    //    // hand 위치로 포지션 이동
    //    item.transform.position = transform.position;

    //    // 플레이어가 아이템을 잡고 손을 떼엇을 경우 다시 들어가야 하므로,
    //    // n 초 후에 물리 효과 실행 및 아이템 슬롯에 들어가도록 설정
    //    // itemColliderHandler.ChangeKinematic(false)의 참조인 func 선언 및 초기화
    //    Action func = () => itemColliderHandler.ChangeKinematic(false);
    //    itemColliderHandler.Coroutine(func, chanageKinematicDelay);

    //    // 1초 후에 마지맏 그립 아이템 설정
    //    StartCoroutine(SetLatestGripItemCoroutine(itemColliderHandler, 1f));
    //}

    //private bool CheckColliderVisibility(RectTransform scrollPanel, RectTransform other)
    //{
    //    // 현재 객체가 스크롤 패널 내에 있는지 여부 확인
    //    bool isVisible = RectTransformUtility.RectangleContainsScreenPoint(scrollPanel, other.position);

    //    return isVisible;
    //}

    //#endregion
    ///*************************************************
    // *                  Coroutines
    // *************************************************/
    //#region [+]  
    //private IEnumerator SetLatestGripItemCoroutine(ItemColliderHandler item, float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    latestGripItem = item;
    //}

    //#endregion
}
