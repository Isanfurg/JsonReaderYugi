
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
            String path = @"C:\Users\Isanfurg\Documents\C#\JsonReaderYugi\CardsID.txt";
            CardsLoader cLoader = new CardsLoader();
            cLoader.StartDownload(path);
            String pathC = "cards.dat";
            List<Card> ListOfCards = Serializator.DeserializeCards(pathC);
            foreach (Card card in ListOfCards)
            {
                card.ToString();
            }
        }
    }
}
