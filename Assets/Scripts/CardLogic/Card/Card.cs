using UnityEngine;

public enum CardSuit { Hearts, Diamonds, Clubs, Spades }
public enum CardType { Ace, Two, Three, Four, Five, Six, Seven,
    Eight, Nine, Ten, Jack, Queen, King }


[CreateAssetMenu(menuName = "BlackJack/New Card")]
public class Card : ScriptableObject {
    [SerializeField] CardSuit suit;
    [SerializeField] CardType type;
    [SerializeField] GameObject go;

    public CardSuit Suit => suit;
    public CardType Type => type;
    public GameObject GO => go;
}