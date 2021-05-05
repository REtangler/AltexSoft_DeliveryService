using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DeliveryService.Interfaces;

namespace DeliveryService.Logic
{
    public class RegExpression : IRegEx
    {
        public bool CheckNumber(string input)
        {
            var patterns = new[]
            {
                @"\+\d{3}\(\d{2}\)\d{3}\s\d{2}\s\d{2}",
                @"\+\d{12}",
                @"\d{10}",
                @"\d{3}\s\d{3}\s\d{2}\s\d{2}"
            };

            foreach (var pattern in patterns)
            {
                var expression = new Regex(pattern, RegexOptions.Compiled);
                if (expression.IsMatch(input))
                    return true;
            }

            return false;
        }

        public bool CheckAddress(string input)
        {
            var patterns = new[]
            {
                @"(улица)\s[А-Я][а-я]+\,\s(д)\.\s\d+\,\s(кв)\.\s\d+",
                @"(улица)\s[А-Я][а-я]+\.\s(д)\.\d+\,\s(кв)\.\d+",
                @"(ул)\.[А-Я][а-я]+\.(д)\.\d+\,(кв)\.\d+",
                @"(ул)\.[А-Я][а-я]+\.(д)\.\d+",
                @"(ул)\.[А-Я][а-я]+\.(дом)\s\d+\,\s(квартира)\s\d+"
            };

            foreach (var pattern in patterns)
            {
                var expression = new Regex(pattern, RegexOptions.Compiled);
                if (expression.IsMatch(input))
                    return true;
            }

            return false;
        }
    }
}
