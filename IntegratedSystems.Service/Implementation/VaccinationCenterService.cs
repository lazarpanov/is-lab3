using IntegratedSystems.Domain.Domain_Models;
using IntegratedSystems.Repository.Interface;
using IntegratedSystems.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedSystems.Service.Implementation
{
    public class VaccinationCenterService : IVaccinationCenterService
    {
        private readonly IRepository<VaccinationCenter> _vaccinationCenterRepository; 
        public VaccinationCenterService(IRepository<VaccinationCenter> vaccinationCetnerRepository) 
        {
            _vaccinationCenterRepository = vaccinationCetnerRepository;
        }

        public void CreateNewVaccinationCenter(VaccinationCenter v)
        {
            this._vaccinationCenterRepository.Insert(v);
        }

        public void DeleteVaccinationCenter(Guid id)
        {
            this._vaccinationCenterRepository.Delete(this._vaccinationCenterRepository.Get(id));
        }

        public VaccinationCenter GetDetailsForVaccinationCenter(Guid? id)
        {
            return this._vaccinationCenterRepository.Get(id);
        }

        public List<VaccinationCenter> GetAllVaccinationCenters()
        {
            return this._vaccinationCenterRepository.GetAll().ToList();
        }

        public void UpdateExistingVaccinationCenter(VaccinationCenter v)
        {
            this._vaccinationCenterRepository.Update(v);
        }
    }
}
