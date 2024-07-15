namespace CustomerApp.Core.Common
{
    public class PagingParameter
    {
        private const int defaultPageSize = 10;
        private int _pageSize;

        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value == 0 ? defaultPageSize : value; }
        }
    }
}