using ProjectA.Models;
using ProjectA.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.Service
{
    public interface IXetHocBong
    {
        public XetHocBongViewModel[] DanhSachDatHocBong();
    }
}
