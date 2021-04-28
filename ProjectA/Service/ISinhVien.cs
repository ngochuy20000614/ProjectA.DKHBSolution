using ProjectA.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectA.Models
{
    public interface ISinhVien
    {
        IEnumerable<SinhVien> GetStudents { get; }

        SinhVien GetSinhVienById(string Id);

        SinhVien Get(string id);

        SinhVien Create();

        void Add(SinhVien sinhVien);

        void Remove(string Id);

        void Update(SinhVien sinhVien);

        SinhVien[] GetListSV(string search);

        Task<List<SinhVienViewModel>> GetSinhViens();

        public (SinhVien[] books, int pages, int page) Paging(int page);

        int numberPage(int totalProduct, int limit);
        IEnumerable<SinhVien> paginationProduct(int start, int limit);
        int totalProduct();

    }
}
