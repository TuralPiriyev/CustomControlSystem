using CustomControlSystem.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomControlSystem.Model
{
    public class ConfigurationModel
    {
        public string DbHost { get; set; }
        public int DbPort { get; set; }
        public DatabaseType DbType { get; set; }
        public string DbName { get; set; }
        public bool WindowsAuthentication { get; set; }
        public string Username { get; set; }
    }
}
