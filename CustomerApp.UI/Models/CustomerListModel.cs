namespace CustomerApp.UI.Models
{
    public class CustomerListModel
    {
        public List<GetCustomerModel> customerModel { get; set; }
        public PaginationMetaData paginationMetaData { get; set; }
    }

    public class GetCustomerModel
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public bool isActive { get; set; }
    }

    public class PaginationMetaData
    {
        public int totalCount { get; set; }
        public int currentPage { get; set; }
        public int totalPage { get; set; }
        public int pageSize { get; set; }
        public bool hasPreviousPage { get; set; }
        public bool hasNextPage { get; set; }
    }
}
