using EMSWebProject.Models;
using EMSWebProject.ViewModel;

namespace EMSWebProject.Interface
{
    public interface IAssetsRepository
    {
        Task<int> AddAssetsAsync(Assets assets);
        Task<IEnumerable<Assets>> GetAssetRecords();
        Task<Assets> GetAssetsRecordById(int id);
        Task<int> UpdateAssetsRecords(Assets assets);
        Task<int> DeleteAssetsRecords(int id);
        Task<EmployeeAssestViewModel> EmployeeAssetList();
        Task<int> AssignEmployeeAsset(EmployeeAssets assignEmployeeAssets);
        Task<IEnumerable<ListEmployeeAssetViewModel>> ListAssetandEmployee(int id);
    }
}
