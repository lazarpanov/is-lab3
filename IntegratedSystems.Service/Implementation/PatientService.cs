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
    public class PatientService : IPatientService
    {
        private readonly IRepository<Patient> _patientRepository;

        public PatientService(IRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public void CreateNewPatient(Patient p)
        {
            this._patientRepository.Insert(p);
        }

        public void DeletePatient(Guid id)
        {
            this._patientRepository.Delete(this._patientRepository.Get(id));
        }

        public List<Patient> GetAllPatients()
        {
            return this._patientRepository.GetAll().ToList();
        }

        public Patient GetDetailsForPatient(Guid? id)
        {
            return this._patientRepository.Get(id);
        }

        public void UpdateExistingPatient(Patient p)
        {
            this._patientRepository.Update(p);
        }
    }
}
