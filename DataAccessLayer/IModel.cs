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
        List<User> GetUsers();
        void Save<T>(String file, T item);
        void CreateFolder(String folder);
        Elements ReadElements(String file);
     }
}
