using System.Threading.Tasks;
using Models.ViewModels;

namespace Logic.Interfaces
{
    public interface IHomeService
    {
        /// <summary>
        /// Сохранение пользовательской информации
        /// </summary>
        /// <param name="model"> данные пользователя </param>
        /// <returns></returns>
        Task SaveUserDataAsync(HomeViewModel model);
    }
}