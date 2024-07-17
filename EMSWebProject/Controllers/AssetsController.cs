using EMSWebProject.Interface;
using EMSWebProject.Models;
using EMSWebProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EMSWebProject.Controllers
{
    public class AssetsController : Controller
    {
        private readonly IAssetsRepository _assetsRepository;
        public AssetsController(IAssetsRepository assetsRepository)
        {
            _assetsRepository = assetsRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

       
        public  IActionResult AddAssets()
        {
            return View();
        }

        [HttpPost]
        [Route("Assets/AddAssets")]
        public async Task<IActionResult> AddAssets(Assets assets)
        {
           var result =await _assetsRepository.AddAssetsAsync(assets);
            if(result == 0)
            {
                throw new Exception("Record not added");
            }
            return RedirectToAction("GetAssetRecords");
        }

       
       
        public async Task<IActionResult> GetAssetRecords()
        {
            try
            {
                var result = await _assetsRepository.GetAssetRecords();
                if(result == null)
                {
                    throw new Exception();
                }
                return View(result);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
      
        }

        

        public async Task<IActionResult> GetAssetsRecordById(int id)
        {
            var result = await _assetsRepository.GetAssetsRecordById(id);
            return View(result);
        }

        [HttpPost]
        [Route("Assets/UpdateAssetsRecords")]
      public async Task<IActionResult> UpdateAssetsRecords(Assets assets)
        {
            var result = await _assetsRepository.UpdateAssetsRecords(assets);
            return RedirectToAction("GetAssetRecords");
        }

        
        [Route("Assets/DeleteAssetsRecords/{id}")]
        public async Task<IActionResult> DeleteAssetsRecords(int id)
        {
            var result = await _assetsRepository.DeleteAssetsRecords(id);
            if(result > 0)
            {
              return RedirectToAction("GetAssetRecords");
            }
            return View("AddAssets");
        }

       
        public async Task<IActionResult> AssignAssets()
        {
           var result = await _assetsRepository.EmployeeAssetList();

            return View(result);
        }

        [HttpPost]
        [Route("Assets/AssignAssets")]
        public async Task<IActionResult> AssignAssets(EmployeeAssets employeeAssets)
        {
           var result = await _assetsRepository.AssignEmployeeAsset(employeeAssets);
            if (result > 0) 
            {
                return RedirectToAction("ListAssestWithEmployee");
            }
            return View();
        }

        public async Task<IActionResult> ListAssestWithEmployee()
        {
          var result = await  _assetsRepository.ListAssetandEmployee();
            return View(result);    
        }
    }
}
