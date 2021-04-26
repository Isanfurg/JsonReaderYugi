using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
namespace JsonReaderYugi
{
    class Serializator
    {
        public static void SerializeCards(List<Card> CardsList)
        {
            string jsonString = JsonSerializer.Serialize(CardsList);
            File.WriteAllText("cards.dat", jsonString);
        }
        public static List<Card> DeserializeCards(String path)
        {
            List<Card> ListOfCards;
            String jsonString = File.ReadAllText(path);
            ListOfCards = JsonSerializer.Deserialize<List<Card>>(jsonString);
            return ListOfCards;
        }
    }
}
