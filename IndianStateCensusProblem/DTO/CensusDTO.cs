using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndianStateCensusProblem.POCO;

namespace IndianStateCensusProblem.DTO
{
    public class CensusDTO
    {
        public int serialNumber;
        public string stateName;
        public string stateCode;
        public int tin;
        public string state;
        public long population;
        public long area;
        public long density;


        public CensusDTO(StateCodeDAO stateCodesDAO)
        {
            this.serialNumber = stateCodesDAO.serialNumber;
            this.stateName = stateCodesDAO.stateName;
            this.stateCode = stateCodesDAO.stateCode;
            this.tin = stateCodesDAO.tin;
        }
        public CensusDTO(CensusDataDAO censusDataDAO)
        {
            this.state = censusDataDAO.state;
            this.population = censusDataDAO.population;
            this.area = censusDataDAO.area;
            this.density = censusDataDAO.density;
        }
    }
}
