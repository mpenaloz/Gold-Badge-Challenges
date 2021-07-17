using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims
{
    public class ProgramUI
    {
        private ClaimRepo _claimRepo = new ClaimRepo();

        public void Run()
        {
            SeedMethod();
            UI();
        }
        private void UI()
        {
            bool isRunning = true;
            while (isRunning)
            {
                System.Console.WriteLine("What would you like to do?" +
                    "\n1. See all claims" +
                    "\n2. Take Care of next claim" +
                    "\n3. Enter a new claim" +
                    "\n4. Exit Program");
                string userResponse = System.Console.ReadLine();

                switch (userResponse)
                {
                    case "1":
                        ViewClaims();
                        break;

                    case "2":
                        TakeCareOfClaims();
                        break;

                    case "3":
                        NewClaim();
                        break;

                    case "4":
                        //Exit
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public DateTime PromptDateTime(string title)
        {
            Console.WriteLine(title);
            Console.WriteLine("Please insert the day: ");
            var day = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please insert the month: ");
            var month = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please insert the Year: ");
            var year = Convert.ToInt32(Console.ReadLine());

            DateTime dtDate = new DateTime(year, month, day);

            return dtDate;
        }   
        private void TakeCareOfClaims()
        {
            Console.Clear();
            var hello = _claimRepo.GetNextClaim();
            DisplayClaimInfo(hello);
            Console.WriteLine("Do you want to process this claim? (y/n)");
            string userInput = Console.ReadLine();
            if (userInput == "y")
            {
                var success = _claimRepo.RemoveClaimFromList();
                if (success)
                {
                    Console.WriteLine("Your claim has been taken care of");
                }
                else if(!success)
                {
                    Console.WriteLine("Your claim could not be taken care of");
                }
            }
            else
            {
                UI();
            }
            Console.ReadKey();
            
        }
        private void DisplayClaimInfo(Claims claims)
        {
            Console.WriteLine($"{claims.ClaimID}\n" +
                $"{claims.ClaimDescription}\n" +
                $"{claims.ClaimAmount}\n" +
                $"{claims.ClaimType}\n" +
                $"{claims.DateOfIncident}\n" +
                $"{claims.DateOfClaim}\n" +
                $"{claims.IsValid}\n");
        }
        private void ViewClaims()
        {
            var listOfClaims = _claimRepo.GetClaimList();

            Console.Clear();

            foreach (var claim in listOfClaims)
            {
                DisplayClaimInfo(claim);
            }
        }
        private void NewClaim()
        {
            Console.Clear();
            Claims newclaim = new Claims();

            
            Console.WriteLine("Enter the claim type: ");
            newclaim.ClaimType = Console.ReadLine();

            Console.WriteLine("Enter a claim description: ");
            newclaim.ClaimDescription = Console.ReadLine();

            Console.WriteLine("Amount of Damage: ");
            newclaim.ClaimDescription = Console.ReadLine();
            
            DateTime DOA = PromptDateTime("You will now be prompted for the date of the accident");
            newclaim.DateOfIncident = DOA;
            DateTime DOC = PromptDateTime("You will now be prompted for the date of the claim");
            newclaim.DateOfClaim = DOC;
            newclaim.IsValid = Span(DOA, DOC);

            var success = _claimRepo.AddClaimToList(newclaim);
        }
        private bool Span(DateTime doc, DateTime doa)
        {
            var span = doa - doc;
            Console.WriteLine($"Total days: {span.TotalDays}");
            if (span.TotalDays > 30)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void SeedMethod()
        {
            var claimA = new Claims(ClaimType.Car, "Car hit pole", "$4000", new DateTime(2002,10,20), new DateTime(2002,11,30), false);
            var claimB = new Claims(ClaimType.Home, "Blew up", "$400000000", new DateTime(2004,10,15), new DateTime(2004,10,16), true);
            _claimRepo.AddClaimToList(claimA);
            _claimRepo.AddClaimToList(claimB);
        }

    }
}
