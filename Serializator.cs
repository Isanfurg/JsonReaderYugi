using System;
using System.IO;

using System.Collections.Generic;
using Newtonsoft.Json;

namespace JsonReaderYugi
{
    class Serializator
    {


  
        public static void SerializeCards(List<Card> CardsList)
        {

            string jsonString = JsonConvert.SerializeObject(CardsList, Formatting.Indented);
            File.WriteAllText("cards.dat", jsonString);
            Console.WriteLine("Lista de Cartas Serializada Exitosamente!");
        }
        public static void SerializeDeck(Deck deck,String fileName)
        {

            string jsonString = JsonConvert.SerializeObject(deck, Formatting.Indented);
            Console.WriteLine(jsonString);
            File.WriteAllText(fileName+".dat", jsonString);
            Console.WriteLine("Deck " + fileName + " Serializado Exitosamente!");
        }
    }
}
