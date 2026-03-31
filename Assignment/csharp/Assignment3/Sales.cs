using System;
namespace SalesDetils
{
    class SaleDetails
    {
        public int SalesNo;
        public int ProductNo;
        public decimal Price;
        public int Qty;
        public DateTime DateOfSale;
        public decimal TotalAmount;
        public SaleDetails(int salesNo, int productNo, decimal price, int qty, DateTime dateOfSale)
        {
            SalesNo = salesNo;
            ProductNo = productNo;
            Price = price;
            Qty = qty;
            DateOfSale = dateOfSale;
        }
        public void Sales()
        {
            TotalAmount = Qty * Price;
        }
        public static void ShowData(SaleDetails s)
        {
            Console.WriteLine("Sales No     : " + s.SalesNo);
            Console.WriteLine("Product No   : " + s.ProductNo);
            Console.WriteLine("Price        : " + s.Price);
            Console.WriteLine("Quantity     : " + s.Qty);
            Console.WriteLine("Date of Sale : " + s.DateOfSale.ToShortDateString());
            Console.WriteLine("Total Amount : " + s.TotalAmount);
        }

        static void Main()
        {
            Console.WriteLine("Enter Sale Number");
            int salesNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Product Number");
            int productNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Price ");
            decimal price = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter Quantity");
            int qty = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Date of Sale");
            DateTime dateOfSale = Convert.ToDateTime(Console.ReadLine());
            SaleDetails sale = new SaleDetails( salesNo, productNo,price,qty,dateOfSale);
            sale.Sales();
            SaleDetails.ShowData(sale);
        }
    }
}

