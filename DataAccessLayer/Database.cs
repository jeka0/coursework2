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
            try
            {
                users = Read<List<User>>(file);
            }
            catch { users = new List<User>(); Save<List<User>>(file, users); }
        }
        public void Save<T>(String file, T item)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(file, FileMode.Create))
            {
                formatter.Serialize(fs, item);
            }
        }
        public T Read<T>(String file)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                return (T)formatter.Deserialize(fs);
            }
        }
        public void CreateFolder(String folder)
        {
            Directory.CreateDirectory(folder);
        }
        public Elements ReadElements(String file)
        {
            if (File.Exists(file))
            {
                return Read<Elements>(file);
            }
            else 
            {
                var elements = new Elements();
                elements.categories.Add("Общее");
                Save<Elements>(file, elements);
                return elements;
            }
        }
    }
}
