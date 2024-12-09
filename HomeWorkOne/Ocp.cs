using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkOne
{
    internal class Ocp
    {
        internal enum MedicineType
        {
            Parol,
            Nurofen,
            Majezik
        }

        public interface IMedicineCalculate
        {
            decimal CalculateMedicinePrice(decimal basePrice);

        }
        internal class ParolPriceCalculate:IMedicineCalculate
        {
            public decimal CalculateMedicinePrice(decimal basePrice)
            {
                return basePrice + (basePrice * 0.08m);
            }
            
        }
        internal class NurofenPriceCalculate : IMedicineCalculate
        {
            public decimal CalculateMedicinePrice(decimal basePrice)
            {
                return basePrice + (basePrice * 0.05m);
            }

        }
        internal class MajezikPriceCalculate : IMedicineCalculate
        {
            public decimal CalculateMedicinePrice(decimal basePrice)
            {
                return basePrice + (basePrice * 0.18m);
            }

        }
        
        internal class MedicinePrice
        {
            public decimal CalculateMedicinePrice(decimal basePrice,IMedicineCalculate medicineCalculate)
            {
                return medicineCalculate.CalculateMedicinePrice((decimal)basePrice);
            }
            public decimal CalculateMedicinePriceAsDelegate(decimal basePrice,Func<decimal,decimal>PriceFunc)
            {
                return PriceFunc(basePrice);
            }
            /*
            public decimal CalculateMedicinePrice(decimal basePrice, MedicineType medicineType)
            {
                if (medicineType == MedicineType.Parol)
                {
                    return basePrice + (basePrice * 0.08m);
                }
                else if (medicineType == MedicineType.Nurofen)
                {
                    return basePrice + (basePrice * 0.05m);
                }
                else 
                {
                    return basePrice + (basePrice * 0.18m);
                }
            }*/
        }
    }
}
