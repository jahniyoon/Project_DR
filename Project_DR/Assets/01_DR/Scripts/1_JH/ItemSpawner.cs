using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Jihwan
{
    public class ItemSpawner : MonoBehaviour
    {
        public enum Spawn { Item, Anvil, Enhance }
        public Spawn spawnItem;
        public int itemID;        

        // Start is called before the first frame update
        void Start()
        {
            GameObject item = new GameObject(); ;
            switch(spawnItem)
            {
                case Spawn.Item:
                    item = Unit.AddFieldItem(this.transform.position, itemID);
                    break;
                case Spawn.Anvil:
                    item = Unit.CreateAnvil(this.transform.position);
                    break;
                case Spawn.Enhance:
                    item = Unit.CreateEnhance(this.transform.position);
                    break;
            }
            item.transform.rotation = this.transform.rotation;
            
        }
    }
}
