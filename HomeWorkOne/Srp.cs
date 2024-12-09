using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HomeWorkOne.Srp;

namespace HomeWorkOne
{
    internal class Srp
    {
        public interface IPharmacyService
        {
            int GetMedicineStock();
            string GetMedicineName();
        }

        public class PharmacyManagment:IPharmacyService
        {
            /* Yanlış Yapı
             
                public int GetMedicineStock()
                {
                return 100;
                }
                public string GetMedicineName()
                {
                    return "Parol";
                }

                public void SendCargo()
                {
                    //Kargolama işlemi
                }
            */
            // Srp =>

            public int GetMedicineStock()
            {
                return 100;
            }
            public string GetMedicineName()
            {
                return "Parol";
            }
        }

        public class CargoService 
        { 
            public void SendCargo(IPharmacyService pharmacyService)
            {
                    string medicineName = pharmacyService.GetMedicineName();

                Console.WriteLine($"{medicineName} ilacı kargo işlemi başlatıldı ");
            }
        }
        public class EmailService
        {
            public void SendEmail(IPharmacyService pharmacyService)
            {
                int medicinestock = pharmacyService.GetMedicineStock();
                Console.WriteLine($"{medicinestock} adet ilaç gönderildi");
            }
        }

    }
}
