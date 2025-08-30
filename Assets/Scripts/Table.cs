using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour {
    [SerializeField] List<Card> cards;
    CardDisplay visual;
    Deck deck;
    Dealer dealer;
    Player player;

    void Start() {
        visual = FindFirstObjectByType<CardDisplay>();

        DeckInit();
        DealerInit();
        PlayerInit();

        StartHand();
    }

    public void StartHand() {
        ClearHands();

        player.Hand.Add(deck.DealCard());
        visual.DrawPlayerCard();
        player.Hand.Add(deck.DealCard());
        visual.DrawPlayerCard();
    }

    void ClearHands() {
        player.Hand.Clear();
        dealer.Hand.Clear();
    }

    void DeckInit() {
        deck = new Deck(cards);
        deck.ShuffleDeck();
    }
    void DealerInit() => dealer = FindFirstObjectByType<Dealer>();
    void PlayerInit() => player = FindFirstObjectByType<Player>();
}