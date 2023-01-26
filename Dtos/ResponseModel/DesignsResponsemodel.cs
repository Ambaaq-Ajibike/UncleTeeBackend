namespace Backend.Dtos.ResponseModel
{
    public class DesignsResponsemodel : BaseResponse
    {
        public List<DesignDto> Data{get; set;} = new List<DesignDto>();
    }
}