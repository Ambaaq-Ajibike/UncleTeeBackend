using Backend.Dtos;
using Backend.Dtos.ResponseModel;

namespace Backend.Interface.Services
{
    public interface IDesignService
    {
        Task<BaseResponse> Add(DesignDto design);
        Task<BaseResponse> Delete(string name);
        Task<DesignResponsemodel> Get(string name);
        Task<DesignsResponsemodel> GetAll();
    }
}