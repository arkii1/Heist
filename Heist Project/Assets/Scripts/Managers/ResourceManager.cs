using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "Managers/Resources Manager")]
    public class ResourceManager : ScriptableObject
    {
        public List<Item> allItems = new List<Item>();
        Dictionary<string, Item> itemDict = new Dictionary<string, Item>();

        public void Init()
        {
            for (int i = 0; i < allItems.Count; i++)
            {
                if (!itemDict.ContainsKey(allItems[i].name))
                {
                    itemDict.Add(allItems[i].name, allItems[i]);
                }
                else
                {
                    Debug.Log("There are two items named " + allItems[i].name + "! This is not allowed.");
                }
            }
        }

        public Item GetItemInstance(string targetID)
        {
            Item defaultItem = GetItem(targetID);
            Item newItem = Instantiate(defaultItem);
            newItem.name = defaultItem.name;

            return newItem;
        }

        public Item GetItem(string targetID)
        {
            Item retVal = null;
            itemDict.TryGetValue(targetID, out retVal);
            return retVal;
        }
    }

}
