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
        T Read<T>(String file);
        void CreateFolder(String folder);
        void DeleteFile(String file);
        void DeleteFolder(String folder);
     }
}
