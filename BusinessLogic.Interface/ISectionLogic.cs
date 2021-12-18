using Domain;

namespace BusinessLogic.Interface
{
    public interface ISectionLogic : ICrud<Section>
    {
        bool Exists(string name);
    }
}