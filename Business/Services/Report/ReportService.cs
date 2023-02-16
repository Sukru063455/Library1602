

using AppCore.DataAccess.EntityFramework.Bases;
using Business.Models.Report;
using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Business.Services.Report
{
    public interface IReportService
    {
        List<ReportItemModel> GetReport(ReportFilterModel filter, bool useInnerJoin = false);
    }
    public class ReportService : IReportService
    {
        private readonly BookRepo _repo;

        public ReportService(BookRepo repo)
        {
            _repo = repo;
        }
        public List<ReportItemModel> GetReport(ReportFilterModel filter, bool useInnerJoin = false)
        {
            var BookQuery = _repo.Query();
            var categoryQuery = _repo.Query<Category>();

            IQueryable<ReportItemModel> query = null;
            if (useInnerJoin)
            {
                query = from p in BookQuery
                        join c in categoryQuery
                        on p.CategoryId equals c.Id

                        select new ReportItemModel
                        {
                            CategoryDescription = c.Description,
                            CategoryName = c.Name,
                            BookDescription = p.Description,
                            BookName = p.Name                            
                        };
            }
            else //left outer joın
            {
                query = from p in BookQuery
                        join c in categoryQuery
                        on p.CategoryId equals c.Id into categoryJoin
                        from category in categoryJoin.DefaultIfEmpty()
                        select new ReportItemModel()
                        {
                            CategoryDescription = category.Description,
                            CategoryName = category.Name,
                            BookDescription = p.Description,
                            BookName = p.Name                          
                        };                
            }
            //query = query.OrderBy(q => q.StoreName).ThenBy(q => q.CategoryName).ThenBy(q => q.ProductName);

            //if (filter is not null)
            //{
            //    if (filter.CategoryId.HasValue)
            //        query = query.Where(q => q.CategoryId == filter.CategoryId);
            //    if (!string.IsNullOrWhiteSpace(filter.ProductName))
            //        query = query.Where(q => q.ProductName.ToLower().Contains(filter.ProductName.ToLower().Trim()));
            //    if (filter.ExpirationDateBegin.HasValue)
            //        query = query.Where(q => q.ExpirationDateValue >= filter.ExpirationDateBegin);
            //    if (filter.ExpirationDateEnd.HasValue)
            //        query = query.Where(q => q.ExpirationDateValue <= filter.ExpirationDateEnd);
            //    if (filter.StoreIds is not null && filter.StoreIds.Count > 0)
            //        query = query.Where(q => filter.StoreIds.Contains(q.StoreId ?? 0));
            //}
            return query.ToList();
        }
    }
}
