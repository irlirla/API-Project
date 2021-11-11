namespace FranchiseService.Mapper
{
    public interface IMapper<in i, out o>
    {
        o Map(i item);
    }
}
