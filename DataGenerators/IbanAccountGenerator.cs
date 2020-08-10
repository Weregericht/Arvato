using DataGenerators.Dictionaries;
using System;

namespace DataGenerators
{
	public class IbanAccountGenerator
	{
		public static string GetValidIbanAccountForCountry(AvailableCountries countryName)
		{
			
			switch (countryName)
			{
				case AvailableCountries.Austria:
					return "AT766000018495388714";
				case AvailableCountries.Germany:
					return "DE13500105177673993747";
				case AvailableCountries.Switzerland:
					return "CH3689144183454384796";
				case AvailableCountries.Finland:
					return "FI8354639957485826";
				case AvailableCountries.Sweden:
					return "SE9266988579412682373348";
				case AvailableCountries.Norway:
					return "NO9386011117947";
				case AvailableCountries.Denmark:
					return "DK2650515213559878";
				case AvailableCountries.OtherCountry:
					return "CY86413154934919955369933756";
			}
			return "";
		}

		public static string GetInvalidIbanAccount()
		{
			return "AE" + GetRandomAcccountNumber(33); ;
		}

		private static string GetRandomAcccountNumber(int accountLength)
		{
			var random = new Random();
			string accountNumber = "";
			int i = 0;
			while (i < accountLength)
			{
				var randomNumber = random.Next(0, 9).ToString();
				accountNumber += randomNumber;
				i++;
			}
			return accountNumber;
		}
	}
}
