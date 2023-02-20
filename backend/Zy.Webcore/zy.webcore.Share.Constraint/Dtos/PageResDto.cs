using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Constraint.Dtos
{
    [Serializable]
    public class PageResDto<T> : IDto
    {
        private IReadOnlyList<T> _data = Array.Empty<T>();

        public PageResDto()
        {
        }

        public PageResDto(BasePageSearchDto search)
            : this(search, default, default)
        {
        }

        public PageResDto(BasePageSearchDto search, IReadOnlyList<T> data, int count)
            : this(search.PageIndex, search.PageSize, data, count)
        {
          
        }

        public PageResDto(int pageIndex, int pageSize, IReadOnlyList<T> data, int count)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalCount = count;
            this.Data = data;
        }

        public IReadOnlyList<T> Data
        {
            get => _data;
            set => _data = value ?? Array.Empty<T>();
        }

        public int RowsCount => _data.Count;

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int PageCount => (int)Math.Ceiling((double)this.TotalCount / (double)this.PageSize);

    }
}
