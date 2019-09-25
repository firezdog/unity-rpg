using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    [SerializeField] string itemName;
    public string ItemName { get => itemName; set => itemName = value; }
    [SerializeField, TextArea] string description;
    public string Description { get => description; set => description = value; }
    [SerializeField] Sprite itemImage;
    public Sprite ItemImage { get => itemImage; set => itemImage = value; }
}
