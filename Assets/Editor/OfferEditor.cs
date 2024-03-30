using OffersLogic.OffersDataLogic;
using UnityEditor;
using UnityEngine;
namespace Editor
{
    // [CustomEditor(typeof(OffersData))]
    // public class OffersDataEditor : UnityEditor.Editor
    // {
    //     public override void OnInspectorGUI()
    //     {
    //         OffersData itemManager = (OffersData)target;
    //
    //         if (GUILayout.Button("Add Item"))
    //         {
    //             GenericMenu menu = new GenericMenu();
    //             menu.AddItem(new GUIContent("OfferWithDescription"), false, () => AddItem<OfferWithDescriptionData>(itemManager));
    //             // menu.AddItem(new GUIContent("Food"), false, () => AddItem<Food>(itemManager));
    //             // menu.AddItem(new GUIContent("Clothes"), false, () => AddItem<Clothes>(itemManager));
    //             menu.ShowAsContext();
    //         }
    //
    //         serializedObject.Update();
    //         EditorGUILayout.PropertyField(serializedObject.FindProperty("itemList"), true);
    //         serializedObject.ApplyModifiedProperties();        }
    //
    //     void AddItem<T>(OffersData itemManager) where T : OfferData, new()
    //     {
    //         T newItem = new T();
    //         // newItem.itemName = "New " + typeof(T).Name;
    //         // newItem.itemID = itemManager.itemList.Count;
    //         itemManager.itemList.Add(newItem);
    //         EditorUtility.SetDirty(itemManager); // Обновляем данные в редакторе
    //     }
    // }
}