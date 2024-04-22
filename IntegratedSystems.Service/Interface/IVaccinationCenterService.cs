using IntegratedSystems.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedSystems.Service.Interface
{
    public interface IVaccinationCenterService
    {
        List<VaccinationCenter> GetAllVaccinationCenters();
        VaccinationCenter GetDetailsForVaccinationCenter(Guid? id);
        void CreateNewVaccinationCenter(VaccinationCenter v);
        void UpdateExistingVaccinationCenter(VaccinationCenter v);
        void DeleteVaccinationCenter(Guid id);
    }
}
