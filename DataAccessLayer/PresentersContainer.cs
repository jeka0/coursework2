using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PresentersContainer
    {
        public IMainPresenter MainPresenter { get; set; }
        public ILoginPresenter LoginPresenter { get; set; }
    }
}
