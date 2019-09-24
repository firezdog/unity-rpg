using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    [SerializeField] string itemName;
    [SerializeField, TextArea] string description;
    [SerializeField] Sprite itemImage;
}
