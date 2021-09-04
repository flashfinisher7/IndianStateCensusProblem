using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusProblem.DTO
{
    public class StateCodeDAO
    {

        public int serialNumber;
        public string stateName;
        public int tin;
        public string stateCode;

        public StateCodeDAO(string serialNumber, string tin, string stateName, string stateCode)
        {
            this.serialNumber = Convert.ToInt32(serialNumber);
            this.tin = Convert.ToInt32(tin);
            this.stateName = stateName;
            this.stateCode = stateCode;
        }
    }
}
