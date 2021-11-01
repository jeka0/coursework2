using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public interface IMainView
    {
        IPresenter presenter { get; set; }
        String GetDate { get; }
        String GetTime { get; }
        String GetCategory { get; }
        String GetComment { get; }
        String SetSum { set; }
        double GetAmount { get; }
        String SetLogin { set; }
        String SetSurname { set; }
        String SetName { set; }
        ComboBox GetCategories { get; }
        ComboBox GetCategories2 { get; }
        int GetIndx { get; }
        Panel GetScreen { get; }
        String GetNewCategory { get; }
        Label GetLabel { get; }
    }
}
