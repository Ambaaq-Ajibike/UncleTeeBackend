using Backend.Dtos;
using Backend.Dtos.ResponseModel;
using Backend.Entities;
using Backend.Interface.Repositories;
using Backend.Interface.Services;
using Mapster;

namespace Backend.Implementation.Services
{
    public class DesignService : IDesignService
    {
        private readonly IRepository<Design> _designRepository;
        public DesignService(IRepository<Design> designRepository) => (_designRepository) = (designRepository);
        public async Task<BaseResponse> Add(DesignDto designDto)
        {
            var exist = await _designRepository.Exist(x => x.Name.ToLower() == designDto.Name.ToLower());
            if(exist) return new BaseResponse{
                Status = false,
                Message = "Design with this name already exist"
            };

            var design = designDto.Adapt<Design>();

            await _designRepository.Add(design);

            return new BaseResponse{
                Status = true,
                Message = "New design added successfully"
            };
        }

        public async Task<BaseResponse> Delete(string name)
        {
            var design = await _designRepository.Get(x => x.Name.ToLower() == name.ToLower());
            if(design == null) return new BaseResponse{
                Status = false,
                Message = "Design with this name doesn't exist"
            };
            await _designRepository.Delete(design);
            return new BaseResponse{
                Status = true,
                Message = "Design successfully deleted"
            };
        }

        public async Task<DesignResponsemodel> Get(string name)
        {
            var design = await _designRepository.Get(x => x.Name.ToLower() == name.ToLower());
            if(design == null) return new DesignResponsemodel{
                Status = false,
                Message = "Design with this name doesn't exist"
            };
            var designDto = design.Adapt<DesignDto>();
            return new DesignResponsemodel{
                Status = true,
                Message = $"{name} successfully retrieve",
                Data = designDto
            };
        }

        public async Task<DesignsResponsemodel> GetAll()
        {
             var design = await _designRepository.GetAll(x => true);
            if(design.Count == 0) return new DesignsResponsemodel{
                Status = false,
                Message = "Design with this name doesn't exist"
            };
            var designDto = design.Adapt<List<DesignDto>>();
            return new DesignsResponsemodel{
                Status = true,
                Message = $"List of designs",
                Data = designDto
            };
        }
    }
}