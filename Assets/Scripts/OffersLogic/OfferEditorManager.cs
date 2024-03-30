using OffersLogic.OffersDataLogic;
using UnityEditor;
using UnityEngine;

namespace OffersLogic
{
    public class OfferEditorManager 
    {
        // public override void OnInspectorGUI()
        // {
        //     OffersData itemManager = (OffersData)target;
        //
        //     if (GUILayout.Button("Add Item"))
        //     {
        //         GenericMenu menu = new GenericMenu();
        //         menu.AddItem(new GUIContent("OfferWithDescription"), false, () => AddItem<OfferWithDescriptionData>(itemManager));
        //         // menu.AddItem(new GUIContent("Food"), false, () => AddItem<Food>(itemManager));
        //         // menu.AddItem(new GUIContent("Clothes"), false, () => AddItem<Clothes>(itemManager));
        //         menu.ShowAsContext();
        //     }
        //
        //     DrawDefaultInspector();
        // }
        //
        // void AddItem<T>(OffersData itemManager) where T : OfferData, new()
        // {
        //     T newItem = new T();
        //     // newItem.itemName = "New " + typeof(T).Name;
        //     // newItem.itemID = itemManager.itemList.Count;
        //     itemManager.itemList.Add(newItem);
        // }
    }
}