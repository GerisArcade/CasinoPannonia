using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;

public class Deck {
    List<Card> deck;



    public Deck(List<Card> deck) {
        this.deck = deck;
    }

    public void ShuffleDeck() {
        RandomNumberGenerator.Create();
        deck = deck.OrderBy(i => RandomNumberGenerator.GetInt32(deck.Count)).ToList();
    }
    public Card DealCard() {
        if (deck.Count <= 0) return null;

        var card = deck[0];
        deck.RemoveAt(0);
        return card;
    }
}