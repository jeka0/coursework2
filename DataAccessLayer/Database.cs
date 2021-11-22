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
        public Elements Expenses { get; set; }
        public Elements Income { get; set; }
        public User SelectedUser { get; set; }
        public List<User> Users { get; set; }
        public MonthlyReport SelectedMonthlyReport { get; set; }
        public List<MonthlyReport> MonthlyReports { get; set; }
        public static Database Db { get; set; }
        public Database(String file)
        {
            Db = this;
            try
            {
                Users = Read<List<User>>(file);
                if(Users==null) Users = new List<User>();
            }
            catch { Users = new List<User>(); Save<List<User>>(file, Users); }
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
