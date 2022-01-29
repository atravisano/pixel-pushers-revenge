using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{

    public string title;
    public string description;
    public Sprite image;
    public int collectableMultiplier;
    public int collectableOverTime; // number of collectable automatically gianed over time
    public int collectableLoss; // Instant
    public int collectableGain; // Instant
    public int speedMultiplier;
    public int jumpHeight;
    public int massMultiplier;
    public int DmgOverTime; // number of collectables automatically lost over time
    public int floorDmg; // number of collectables lost over time wil player is on floor level
    public int fallDmg; // number of collectables lost when dropping to floor level
    public int sizeMultiplier; // the player sprites size
    public int removeCards;

    public int invincibilityTime;

    
}
