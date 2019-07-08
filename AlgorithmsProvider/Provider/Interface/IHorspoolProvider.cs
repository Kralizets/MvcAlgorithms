using AlgorithmsProvider.Models;

namespace AlgorithmsProvider.Provider.Interface
{
    public interface IHorspoolProvider
    {
        HorspoolModel AlgorithmHorspul(string currentString, string searchString);
    }
}