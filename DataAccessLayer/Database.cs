using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using BusinessLayer;
using System.Xml.Serialization;

namespace DataAccessLayer
{
    public class Database : IModel
    {
        List<User> users;
        public List<User> GetUsers { get { return users; } }
        public Database(String file)
        {
            ReadUsersXml("Data/"+file);
        }
        public void SaveXml<T>(String file, T item)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(file, FileMode.Create))
            {
                formatter.Serialize(fs, item);
            }
        }
        public void CreateFolder(String folder)
        {
            Directory.CreateDirectory(folder);
        }
        public void ReadUsersXml(String file)
        {
            if (File.Exists(file))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<User>));
                using (FileStream fs = new FileStream(file, FileMode.Open))
                {
                    users = (List<User>)formatter.Deserialize(fs);
                }
            }
            else { users = new List<User>(); SaveXml<List<User>>(file, users); }
        }
        public Elements ReadElementsXml(String file)
        {
            if (File.Exists(file))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(Elements));
                using (FileStream fs = new FileStream(file, FileMode.Open))
                {
                    return (Elements)formatter.Deserialize(fs);
                }
            }
            else 
            {
                var elements = new Elements();
                elements.categories.Add("Общее");
                SaveXml<Elements>(file, elements);
                return elements;
            }
        }
    }
}
