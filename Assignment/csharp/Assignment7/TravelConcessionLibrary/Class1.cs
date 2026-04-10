using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelConcessionLibrary
{
    public class ConcessionCalculator
        {
            // Method to calculate concession
            public string CalculateConcession(int age, decimal totalFare)
            {
                if (age <= 5)
                {
                    return "Little Champs - Free Ticket";
                }
                else if (age > 60)
                {
                    decimal concession = totalFare * 0.30m;
                    decimal finalFare = totalFare - concession;
                    return $"Senior Citizen - Fare after concession: {finalFare}";
                }
                else
                {
                    return $"Ticket Booked - Fare: {totalFare}";
                }
            }
        }
    
}
