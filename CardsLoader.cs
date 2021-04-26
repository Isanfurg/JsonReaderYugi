using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace JsonReaderYugi
{
   
    class CardsLoader
    {
        private const string pathCards = @"sources\cards\";
        private const string pathSmallCards = @"sources\smallCards\";
        WebClient client = new();
        List<Card> ListOfcards = new List<Card>();

        public void StartDownload(string path)
        {
            using (StreamReader ReaderObject = new StreamReader(path))
            {
                string Line;
                // ReaderObject reads a single line, stores it in Line string variable and then displays it on console
                while ((Line = ReaderObject.ReadLine()) != null)
                {
                    getJasonFromApiCard(Line);
                    client = new();
                }
                Console.WriteLine("Se guardaron las cartas");
                Serializator.SerializeCards(ListOfcards);
            }


        }

        private void getJasonFromApiCard(String id)
        {
            Card card = new();
            String url = "https://db.ygoprodeck.com/api/v7/cardinfo.php?id=" + id;
            String myJson = client.DownloadString(url);
            var file = Newtonsoft.Json.JsonConvert.DeserializeObject(myJson);
            //get values from data in json file
            var prop = ((JProperty)((JObject)file).First).Value;
            foreach (JObject item in ((JArray)prop).Children())
            {
                //To get value use JProperty.Value\
                JProperty ID = item.Properties().FirstOrDefault(p => p.Name.Contains("id"));
                JProperty name = item.Properties().FirstOrDefault(p => p.Name.Contains("name"));
                JProperty type = item.Properties().FirstOrDefault(p => p.Name.Contains("type"));
                JProperty def = item.Properties().FirstOrDefault(p => p.Name.Contains("def"));
                JProperty desc = item.Properties().FirstOrDefault(p => p.Name.Contains("desc"));
                JProperty atk = item.Properties().FirstOrDefault(p => p.Name.Contains("atk"));
                JProperty level = item.Properties().FirstOrDefault(p => p.Name.Contains("level"));
                JProperty race = item.Properties().FirstOrDefault(p => p.Name.Contains("race"));
                JProperty attribute = item.Properties().FirstOrDefault(p => p.Name.Contains("attribute"));
                JProperty card_images = item.Properties().FirstOrDefault(p => p.Name.Contains("card_images"));
                String IDF = (String)ID.Value;
                String nameF = (String)name.Value;
                String typeF = (String)type.Value;
                String descF = (String)desc.Value;
                int atkF = (int)atk.Value;
                int defF = (int)def.Value;
                int levelF = (int)level.Value;
                String raceF = (String)race.Value;
                String attributeF = (String)attribute.Value;
                JArray card_imagesF = (JArray)card_images.Value;
                String cardUrl = "";
                String smallCardUrl = "";

                foreach (JObject imagT in card_imagesF.Children())
                {
                    JProperty imgUrl = imagT.Properties().FirstOrDefault(p => p.Name.Contains("image_url"));
                    JProperty smallImgUrl = imagT.Properties().FirstOrDefault(p => p.Name.Contains("image_url_small"));
                    cardUrl = (string)imgUrl.Value;
                    smallCardUrl = (string)smallImgUrl.Value;
                }

                saveImage(cardUrl, IDF);

                saveImageSmall( smallCardUrl, IDF);
                card = new Card(IDF, nameF, typeF, descF, defF, atkF, levelF, raceF, attributeF,cardUrl,smallCardUrl);
                ListOfcards.Add(card);
                break;
            }
            
            Console.WriteLine("Card ID " + id + " has been charged.");
        }

    

        public void saveImage(String imgUrl, String id)
    {
        client.DownloadFile(new Uri(imgUrl), pathCards + id + ".jpg");
    }
        public void saveImageSmall(String imgUrl, String id)
        {
            client.DownloadFile(new Uri(imgUrl), pathSmallCards + id + ".jpg");
        }
    }

}
