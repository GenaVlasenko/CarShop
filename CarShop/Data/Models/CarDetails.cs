using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    public class CarDetails
    {
        public int id { get; set; }

        //public string main_photo { get; set; }
        public string video { get; set; }
        public string first_photo { get; set; }
        public string second_photo { get; set; }
        public string third_photo { get; set; }
        public string four_photo { get; set; }
        public int car_id { get; set; }

    }
}
