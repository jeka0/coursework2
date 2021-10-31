using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IMainView
    {
        IPresenter presenter { get; set; }
        String GetDate { get; }
        String GetTime { get; }
        String GetCategory { get; }
        String GetComment { get; }
        String GetAmount{ get; }
}
}
