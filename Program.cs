
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;

namespace JsonReaderYugi
{
    class Program
    {
        static void Main(string[] args)
        {
            //String path = @"C:\Users\Isanfurg\Documents\C#\JsonReaderYugi\CardsID.txt";
            CardsLoader cLoader = new CardsLoader();
            //cLoader.StartDownload(path);

            String path1 = @"C:\Users\Isanfurg\Documents\C#\JsonReaderYugi\YugiDeck.txt";
            Deck deck1 = new Deck();
            deck1.Id = "1";
            deck1.Name = "Yugi";
            List<Card> deck1List = cLoader.StartDownload(path1);
            foreach(Card card in deck1List)
            {
                deck1.CardList.Add(card.Id);
            }

            String path2 = @"C:\Users\Isanfurg\Documents\C#\JsonReaderYugi\DeckJoey.txt";
            Deck deck2 = new Deck();
            deck2.Id = "2";
            deck2.Name = "Joey";
            List<Card> deck2List = cLoader.StartDownload(path2);
            foreach (Card card in deck2List)
            {
                deck2.CardList.Add(card.Id);
            }

            String path3 = @"C:\Users\Isanfurg\Documents\C#\JsonReaderYugi\DeckKaiba.txt";
            Deck deck3 = new Deck();
            deck3.Id = "3";
            deck3.Name = "Kaiba";
            List<Card> deck3List = cLoader.StartDownload(path3);
            foreach (Card card in deck3List)
            {
                deck3.CardList.Add(card.Id);
            }
            Serializator.SerializeDeck(deck1,"DeckYugi");

            Serializator.SerializeDeck(deck2,"DeckJoey");

            Serializator.SerializeDeck(deck3,"DeckKaiba");
        }
    }
}
