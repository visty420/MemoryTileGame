using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;

namespace MemoryTilesGame
{
    public class User
    {
        private string userName;
        private int imageNumber;

        public User(string userName, int imageIndex)
        {
            this.userName = userName;
            this.imageNumber = imageIndex; 
        }
        public User() { }
        [XmlElement("userName")]
        public string UserNameBinding
        {
            get { return userName; }
            set { userName = value; }
        }
        [XmlElement("imageIndex")]
        public int ImageNumber
        {
            get { return imageNumber; } 
            set { imageNumber = value; } 
        }

    }

    
}
