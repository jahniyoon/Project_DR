using Rito.InventorySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryUI : MonoBehaviour
{
    /*************************************************
     *                 Private Fields
     *************************************************/
    #region [+]
    [Header("Inventory")]
    [SerializeField] private Inventory _inventory;
    [Header("UI")]
    [SerializeField] private ItemTooltipUI _itemTooltip;
    [SerializeField] private GameObject itemSlotPanelPrefab;
    [SerializeField] private List<ItemSlotPanelUI> _itemSlotPanels;
    [SerializeField] private List<Item> _items;
    [SerializeField] private float _itemSlotInterval = 600f;
    private Vector2 _tooltipAnchorPos;
    private float _tooltipInterval = 300f;
    private string _panelName = "ItemSlotPanel";
    #endregion
    /*************************************************
     *                  Unity Events
     *************************************************/
    #region [+]
    void Start()
    {
        _itemSlotPanels = new List<ItemSlotPanelUI>();
        _tooltipAnchorPos = _itemTooltip.GetComponent<RectTransform>().anchoredPosition;

        UpdatePlayerInventory();
    }

    #endregion
    /*************************************************a
     *                Public Methods
     *************************************************/
    #region [+]
    public void UpdatePlayerInventory()
    {
        // 아이템 슬롯 오브젝트 풀링
        CreateSlotPulling();

        // 아이템 슬롯 업데이트
        UpdateItemSlots();
    }

    private void Update()
    {
        UpdateItemSlots();
    }

    public GameObject AddItemSlot()
    {
        GameObject itemSlot = Instantiate(itemSlotPanelPrefab, 
            itemSlotPanelPrefab.transform.parent);
        ItemSlotPanelUI itemSlotPanelUI = itemSlot.GetComponent<ItemSlotPanelUI>();
        //itemSlotPanelUI.Initialize(id);
        itemSlot.SetActive(true);
        _itemSlotPanels.Add(itemSlotPanelUI);
        int index = _itemSlotPanels.Count - 1;
        if (index > 0)
        {
            RectTransform itemSlotRect = itemSlot.GetComponent<RectTransform>();
            Vector2 pos = itemSlotRect.anchoredPosition;
            // 야매로 (_itemSlotInterval / 2) * index로 수정함 왜냐면
            // 다르게 하면 간격이 틀어지는 오류가 발생
            // 나중에 방법 찾으면 해결할 예정
            pos.x += (_itemSlotInterval / 2) * index;
            itemSlotRect.anchoredPosition = pos;
        }

        itemSlot.name = _panelName + " (" + index + ")";
        itemSlotPanelUI.SetIndex(index);

        return itemSlot;
    }

    public void ShowTooltip(int index)
    {
        if (_itemSlotPanels[index])
        {
            ItemSlotPanelUI itemSlotPanelUI = 
                _itemSlotPanels[index].GetComponent<ItemSlotPanelUI>(); 
            UpdateTooltipUI(itemSlotPanelUI.ItemData, index);
            _itemTooltip.Show();
        }
    }

    public void HideToolTip()
    {
        _itemTooltip.Hide();
    }

    private void UpdateTooltipUI(ItemData data, int index)
    {
        // 툴팁 정보 갱신
        _itemTooltip.SetItemInfo(data);

        RectTransform tooltipRect = _itemTooltip.GetComponent<RectTransform>();
        Vector2 tempAnchorPos = _tooltipAnchorPos;
        tempAnchorPos.x += (_tooltipInterval * index);
        // 툴팁 위치 조정
        tooltipRect.anchoredPosition = tempAnchorPos;
    }

    #endregion
    /*************************************************
     *                Private Methods
     *************************************************/
    #region [+]
    private void CreateSlotPulling()
    {
        for (int i = 0; i < _inventory.InitalCapacity; i++)
        {
            GameObject slot = AddItemSlot();
            // 기본 슬롯 3개 표시를 위해 예외처리
            if ((i < 3) == false)
            {
                slot.SetActive(false);
            }
        }
    }

    private void InitSlotData(int id, int amount, int maxAmount, int index)
    {
        _itemSlotPanels[index].Initialize(id, amount, maxAmount, index);
        _itemSlotPanels[index].gameObject.SetActive(true);
    }

    private void ResetSlotData(int id = default, 
        int amount = default, int maxAmount = default, int index = default)
    {
        _itemSlotPanels[index].Initialize(id, amount, maxAmount, index);
        //_itemSlotPanels[index].gameObject.SetActive(true);
    }

    // 아이템 슬롯 업데이트
    private void UpdateItemSlots()
    {
        // 인벤토리 슬롯 개수
        int count = _inventory.InitalCapacity;
        // 인벤토리에 있는 슬롯 개수만큼 순회
        for (int i = 0; i < count; i++)
        {
            // 인벤토리에 슬롯이 비어있지 않을 경우
            if (_inventory.Items[i] != null)
            {
                // 해당 슬롯에 있는 아이템이 PortionItem일 경우
                if (_inventory.Items[i] is PortionItem pi)
                {
                    // 순차적으로 _itemSlotPanels을 순회
                    for (int j = 0; j < count; j++)
                    {
                        // 비어있을 경우
                        if (_itemSlotPanels[j].ItemData == default)
                        {
                            // Init
                            int id = pi.Data.ID;
                            int amount = pi.Amount;
                            int maxAmount = pi.MaxAmount;
                            InitSlotData(id, amount, maxAmount, i);
                        }
                    }
                }

            }
        }
    }

    #endregion
}
