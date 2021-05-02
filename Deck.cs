using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonReaderYugi
{

    [Serializable]
    public class Deck
    {
        public string Id;
        public string Name;
        public List<string> CardList;

        public Deck()
        {
            Id = "";
            Name = "";
            CardList = new();
        }
    }
    
}
