using IntegratedSystems.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedSystems.Service.Interface
{
    public interface IVaccineService
    {
        bool addVaccine(Vaccine v);
        List<Vaccine> getAll();
    }
}
