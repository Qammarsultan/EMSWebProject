using EMSWebProject.Data;
using EMSWebProject.Data.Migrations;
using EMSWebProject.Enum;
using EMSWebProject.Interface;
using EMSWebProject.Models;
using EMSWebProject.ViewModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EMSWebProject.Repository
{
    public class AssetsRepository : IAssetsRepository
    {
        private readonly ApplicationDbContext _context;
        public AssetsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAssetsAsync(Assets assets)
        {
            await _context.tblAssets.AddAsync(assets);
            await _context.SaveChangesAsync();
            return assets.Id;
        }

        

        public async Task<IEnumerable<Assets>> GetAssetRecords()
        {
         var assestList =    await _context.tblAssets.ToListAsync();
         return assestList;
        }

        public async Task<Assets> GetAssetsRecordById(int id)
        {
            var assestList = await _context.tblAssets.Where(x => x.Id == id).FirstOrDefaultAsync();
            return assestList;
        }

        public async Task<int> UpdateAssetsRecords(Assets assets)
        {
            var result = await _context.tblAssets.Where(x => x.Id == assets.Id).FirstOrDefaultAsync();

            result.Name = assets.Name;
            result.Description = assets.Description;
            result.PurchasingPrice = assets.PurchasingPrice;
            result.Status = assets.Status;

             _context.tblAssets.Update(result);
            await _context.SaveChangesAsync();
            return result.Id;
        }

        public async Task<int> DeleteAssetsRecords(int id)
        {
          var result = await _context.tblAssets.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(result != null)
            {
                _context.tblAssets.Remove(result);
                await _context.SaveChangesAsync();
                return result.Id;
            }
            return 0;
        }

        public async Task<EmployeeAssestViewModel> EmployeeAssetList()
        {
            var asset = await _context.tblAssets.ToListAsync();
            var empolyee = await _context.tblEmployeeInfo.ToListAsync();


                      return new EmployeeAssestViewModel
                      {
                          Assets = asset,
                          Employees = empolyee,
                      };
        }

        public async Task<int> AssignEmployeeAsset(EmployeeAssets assignEmployeeAssets)
        {
           var asset = await _context.tblAssets.Where(x => x.Id == assignEmployeeAssets.AssetId).FirstOrDefaultAsync();
            asset.Status = EssetEnum.Assigned.ToString();

             _context.tblAssets.Update(asset);


            await  _context.tblEmployeeAssets.AddAsync(assignEmployeeAssets);
            await _context.SaveChangesAsync();
            return assignEmployeeAssets.Id;
        }

        public async Task<IEnumerable<ListEmployeeAssetViewModel>> ListAssetandEmployee()
        {
          var list = await  _context.tblEmployeeAssets.ToListAsync();

            var res = from e in list
                      join asset in _context.tblAssets
                      on e.AssetId equals asset.Id
                      join emp in _context.tblEmployeeInfo
                      on e.EmployeeId equals emp.Id
                      select new ListEmployeeAssetViewModel
                      {
                          Asset_Name = asset.Name,
                          Description = asset.Description,
                          PurchasingPrice = asset.PurchasingPrice,
                          Status = asset.Status,
                          Emp_Name = emp.Name,
                          CreatedAt = asset.CreatedAt,
                          CreatedBy = asset.CreatedBy,
                      };
                 return res;
        }

    }
    }
