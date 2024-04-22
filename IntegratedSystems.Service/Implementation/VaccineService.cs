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
    public class VaccineService : IVaccineService
    {
        private readonly IRepository<Patient> patientRepostiory;
        private readonly IRepository<VaccinationCenter> vaccinationCenterRepository;
        private readonly IRepository<Vaccine> vaccineRepository;
        public VaccineService(IRepository<Patient> patientRepostiory, IRepository<VaccinationCenter> vaccinationCenterRepository, IRepository<Vaccine> vaccineRepoistory) 
        {
            this.vaccinationCenterRepository = vaccinationCenterRepository;
            this.patientRepostiory = patientRepostiory;
            this.vaccineRepository = vaccineRepoistory;
        }

        public bool addVaccine(Vaccine v)
        {
            var centerId = v.VaccinationCenter;
            var patientId = v.PatientId;

            var newVaccine = new Vaccine
            {
                Id = Guid.NewGuid(),
                Certificate = Guid.NewGuid(),
                Center = vaccinationCenterRepository.Get(centerId),
                DateTaken = v.DateTaken,
                Manufacturer = v.Manufacturer,
                PatientFor = patientRepostiory.Get(patientId),
                VaccinationCenter = v.VaccinationCenter,
            };

            vaccineRepository.Insert(newVaccine);

            var center = vaccinationCenterRepository.Get(centerId);
            center.MaxCapacity -= 1;

            vaccinationCenterRepository.Update(center);
            return true;
        }

        public List<Vaccine> getAll()
        {
            return vaccineRepository.GetAll().ToList();
        }
    }
}
