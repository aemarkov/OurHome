using System.Web.Http;
using Abp.Domain.Repositories;
using Abp.UI;
using Abp.WebApi.Controllers;
using OurHome.Api.Models.Registrator;
using OurHome.Domain;

namespace OurHome.Api.Controllers
{
    /// <summary>
    /// Апи регистратора
    /// </summary>
    public class RegistratorController : AbpApiController
    {
        private readonly IRepository<Registrator> _registratorsRepository;
        private readonly IRepository<ResourceConsumption> _consumptionRepository;

        public RegistratorController(IRepository<Registrator> registratorsRepository,
            IRepository<ResourceConsumption> consumptionRepository )
        {
            _registratorsRepository = registratorsRepository;
            _consumptionRepository = consumptionRepository;
        }

        /*TODO: Исправить механизм регистрации данных
         * 1) Вынести в сервис
         * 2) Нормальные проверки
         * 3) Оптимизировать
         */
        [HttpPost]
        public bool AddConsumption(AddConsumptionModel model)
        {
            if(model==null)
                throw new UserFriendlyException("model empty");


            var registrator = _registratorsRepository.FirstOrDefault(model.RegistratorId);
            if(registrator==null)
                throw new UserFriendlyException("registrator not found");

            _consumptionRepository.Insert(new ResourceConsumption()
            {
                Consumption = model.Consumption,
                RegistratorId = model.RegistratorId
            });

            return true;
        }
    }
}