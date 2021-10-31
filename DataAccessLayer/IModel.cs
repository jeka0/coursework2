using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataAccessLayer
{
     public interface IModel
     {
        List<User> GetUsers { get; }
        void SaveXml<T>(String file, T item);
        void ReadUsersXml(String file);
        void CreateFolder(String folder);
        Elements ReadElementsXml(String file);
     }
}
