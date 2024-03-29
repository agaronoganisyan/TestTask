using OffersLogic.OffersDataLogic;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    // [CustomEditor(typeof(OffersData))]
    // public class OffersDataEditor : UnityEditor.Editor
    // {
    //     SerializedProperty offerTypeProp;
    //     SerializedProperty descriptionProp;
    //     SerializedProperty spriteProp;
    //     SerializedProperty offersProp;
    //
    //     void OnEnable()
    //     {
    //         offerTypeProp = serializedObject.FindProperty("offerType");
    //         descriptionProp = serializedObject.FindProperty("description");
    //         spriteProp = serializedObject.FindProperty("sprite");
    //         offersProp = serializedObject.FindProperty("offers");
    //     }
    //
    //     public override void OnInspectorGUI()
    //     {
    //         serializedObject.Update();
    //
    //         EditorGUILayout.PropertyField(offerTypeProp);
    //
    //         OfferType offerType = (OfferType)offerTypeProp.enumValueIndex;
    //
    //         switch (offerType)
    //         {
    //             case OfferType.None:
    //                 // Do nothing
    //                 break;
    //             case OfferType.OfferWithDescription:
    //                 EditorGUILayout.PropertyField(descriptionProp, new GUIContent("Description"));
    //                 break;
    //             case OfferType.OfferWithIcon:
    //                 EditorGUILayout.PropertyField(spriteProp, new GUIContent("Sprite"));
    //                 break;
    //             case OfferType.OfferWithDescriptionAndIcon:
    //                 EditorGUILayout.PropertyField(descriptionProp, new GUIContent("Description"));
    //                 EditorGUILayout.PropertyField(spriteProp, new GUIContent("Sprite"));
    //                 break;
    //         }
    //
    //         // Display array of offers
    //         EditorGUILayout.PropertyField(offersProp, true);
    //
    //         serializedObject.ApplyModifiedProperties();
    //     }
    // }
}