// See https://aka.ms/new-console-template for more information
using HomeWorkOne;
using HomeWorkOne.DIP;
using static HomeWorkOne.Isp;
using static HomeWorkOne.Lsp;
using static HomeWorkOne.Ocp;
using static HomeWorkOne.Srp;

Console.WriteLine("Hello, World!");

//SRP
IPharmacyService pharmacyService = new PharmacyManagment();
CargoService cargoService = new CargoService();
EmailService emailService = new EmailService();

Console.WriteLine($"İlaç Adı {pharmacyService.GetMedicineName()}");
Console.WriteLine($"Stok miktarı: {pharmacyService.GetMedicineStock()}");

cargoService.SendCargo(pharmacyService);

emailService.SendEmail(pharmacyService);

//OCP

MedicinePrice medicinePrice=new MedicinePrice();
var parolPrice = medicinePrice.CalculateMedicinePrice(15, new ParolPriceCalculate());
var majezikPrice = medicinePrice.CalculateMedicinePrice(15, new MajezikPriceCalculate());

Console.WriteLine("parol "+ parolPrice);
Console.WriteLine("majezi "+ majezikPrice);

Func<decimal, decimal> funcDelegate = (x) => x * 0.8m;
var tylHot = medicinePrice.CalculateMedicinePriceAsDelegate(24, TylHot);
var xmedicine = medicinePrice.CalculateMedicinePriceAsDelegate(50, x => x * 2.9m);

    static decimal TylHot(decimal total)
    {
        return total + (total * 0.08m);
    }
Console.WriteLine("tylhot "+tylHot);
Console.WriteLine("xmedicine " + xmedicine);


//LSP

Car tesla = new Tesla();
Car suzuki = new Suzuki();


tesla.Drive();
suzuki.Drive();


if (tesla is IAutoPilot teslaAutoPilot)
{
    teslaAutoPilot.ActivateAutoPilot();
}

//ISP
CreditCardPayment creditCardPayment = new CreditCardPayment();
creditCardPayment.MobilePay(5800);
BankTransferPayment bankTransferPayment = new BankTransferPayment();
bankTransferPayment.BankTransfer(2400, "ISD5FJ5");

//DIP
var paymentServiceFactory = new PaymentServiceFactory();
var paymentController = new PaymentsController(paymentServiceFactory.CreatePaymentService());
var payments = paymentController.GetPayments();
foreach (var payment in payments)
{
    Console.WriteLine($"Type: {payment.type} Amount: {payment.amount}");
}