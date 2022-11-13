using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16_PacketDecoder
{
    public static class Helper
    {
        private static readonly Dictionary<char, string> HexadecimalDict = new Dictionary<char, string>
        {
            { '0', "0000" },
            { '1', "0001" },
            { '2', "0010" },
            { '3', "0011" },
            { '4', "0100" },
            { '5', "0101" },
            { '6', "0110" },
            { '7', "0111" },
            { '8', "1000" },
            { '9', "1001" },
            { 'A', "1010" },
            { 'B', "1011" },
            { 'C', "1100" },
            { 'D', "1101" },
            { 'E', "1110" },
            { 'F', "1111" }
        };

        public static long Part1(string entry)
        {
            var binary = ConvertToBinary(entry);
            var version = ConvertToDecimal(binary.Substring(0, 3));
            var id = ConvertToDecimal(binary.Substring(3, 3));
            var pachetStartIndex = 6;
            if (id == 4)
            {
                // Literal value, single value encoded
                var pachet = "";
               
                do
                {
                    pachet += binary.Substring(pachetStartIndex + 1, 4);
                    pachetStartIndex += 5;
                } while (binary[pachetStartIndex] == '1');

                pachet += binary.Substring(pachetStartIndex + 1, 4);
                pachetStartIndex += 5;

                var decim = ConvertToDecimal(pachet);
                pachetStartIndex = 4 - pachetStartIndex % 4;

                return decim;
            }
            else
            {
                if(binary[6] == '0')
                {
                    var totalLengthPachet = 15; // total length in bits
                    var newVersion = ConvertToDecimal(binary.Substring(7, 3));
                    var

                }
                else
                {
                    var totalPachets = 11; // total number of pachets
                }
            }
            return 0;
        }

        private static string ConvertToBinary(string hexadecimal)
        {
            var binary = "";
            foreach(var element in hexadecimal)
            {
                binary += HexadecimalDict[element];
            }
            return binary;
        }

        private static long ConvertToDecimal(string binary)
        {
            var decim = 0;
            var index = 0;
            for (var i = binary.Length - 1; i >= 0; i--)
            {
                if(binary[index] == '1')
                {
                    decim += (int) Math.Pow(2, i);
                }
                index++;
            }
            return decim;
        }
    }
}
