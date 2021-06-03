using System.Text.RegularExpressions;
using DeliveryService.Interfaces;

namespace DeliveryService.Logic
{
    public class Validator : IRegEx
    {
        private static readonly string PhoneNumberPattern = @"(\+38)?0\(?\d{2}\)?\s?\d{3}\s?\d{2}\s?\d{2}\b";
        private readonly Regex _regexNumber;

        private static readonly string AddressPattern = @"((ул)(ица)?)(\s|\.)[А-Я][а-я]+(\,|\.)\s?д(ом)?\.?\s?\d+\,?\s?((кв)(артира)?)?\.?\s?\d+\b";
        private readonly Regex _regexAddress;

        public Validator()
        {
            _regexNumber = new Regex(PhoneNumberPattern, RegexOptions.Compiled);
            _regexAddress = new Regex(AddressPattern, RegexOptions.Compiled);
        }

        public bool CheckNumber(string input)
        {
            if (_regexNumber.IsMatch(input))
                return true;

            return false;
        }

        public bool CheckAddress(string input)
        {
            if (_regexAddress.IsMatch(input))
                return true;

            return false;
        }
    }
}
