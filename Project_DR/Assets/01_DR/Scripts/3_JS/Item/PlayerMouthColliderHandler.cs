using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouthColliderHandler : MonoBehaviour
{
    /*************************************************
     *                 Unity Events
     *************************************************/
    #region [+]
    private void OnTriggerEnter(Collider other)
    {
        // 아이템이 입 안에 들어왔을 경우
        if (other.CompareTag("ItemPotion"))
        {
        GFunc.Log("PlayerMouthColliderHandler.OnTriggerEnter");
            // 포션 아이템 사용
            other.GetComponent<UseItem>().Use();
        }
    }

    #endregion
}
