using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YorNService.DataObjects
{
    public class User : EntityData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int ID { get; set; }
    }
}
