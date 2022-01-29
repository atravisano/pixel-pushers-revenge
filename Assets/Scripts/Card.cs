using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{

    public string title;
    public string positive;
    public string negative;
    public Sprite image;
    public float collectableMultiplier;
    public float collectableOverTime; // number of collectable automatically gianed over time
    public float collectableLoss; // Instant
    public float collectableGain; // Instant
    public float speedMultiplier;
    public float jumpHeight;
    public float massMultiplier;
    public float DmgOverTime; // number of collectables automatically lost over time
    public float floorDmg; // number of collectables lost over time wil player is on floor level
    public float fallDmg; // number of collectables lost when dropping to floor level
    public float sizeMultiplier; // the player sprites size
    public int removeCards;
    public int addCards;
    public float invincibilityTime;
    public bool levelSkip;

    
}
