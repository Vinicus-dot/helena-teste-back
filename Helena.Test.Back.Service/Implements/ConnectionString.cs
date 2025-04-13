using Helena.Test.Back.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helena.Test.Back.Service.Implements
{
    public class ConnectionString : IConnectionString
    {
        public string HelenaDbConnectionString { get ; set; }
    }
}
