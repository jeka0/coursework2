using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BusinessLayer;
using System.Xml.Serialization;

namespace DataAccessLayer
{
    public class Database : IModel
    {
        List<User> users;
        public List<User> GetUsers() { return users; } 
        public Database(String file)
        {
            try
            {
                users = Read<List<User>>(file);
                if(users==null) users = new List<User>();
            }
            catch { users = new List<User>(); Save<List<User>>(file, users); }
        }
        public void Save<T>(String file, T item)
        {
            if (File.Exists(file))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                using (FileStream fs = new FileStream(file, FileMode.Create))
                {
                    formatter.Serialize(fs, item);
                }
            }
        }
        public T Read<T>(String file)
        {
            if (File.Exists(file))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                using (FileStream fs = new FileStream(file, FileMode.Open))
                {
                    return (T)formatter.Deserialize(fs);
                }
            }
            else return default;
        }
        public void CreateFolder(String folder)
        {
            Directory.CreateDirectory(folder);
        }
        public void DeleteFile(String file)
        {
            File.Delete(file);
        }
        public void DeleteFolder(String folder)
        {
            Directory.Delete(folder);
        }
    }
}
