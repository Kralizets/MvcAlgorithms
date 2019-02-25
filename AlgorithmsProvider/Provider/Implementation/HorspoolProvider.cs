using AlgorithmsProvider.Models;
using AlgorithmsProvider.Provider.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsProvider.Provider.Implementation
{
    public class HorspoolProvider : IHorspoolProvider
    {
        public HorspoolModel AlgorithmHorspul(string currentString, string searchString)
        {
            if (currentString.Length < searchString.Length)
            {
                return new HorspoolModel
                {
                    InputString = currentString,
                    SearchString = searchString,
                    NumberOfLine = 0,
                    IsFound = false
                };
            }

            Dictionary<char, int> offsetTable = GetOffsetTable(searchString);
            int currentPosition = searchString.Length - 1;
            int maxSearchPosition = currentPosition;
            int maxPosistion = currentString.Length;
            bool isSuccessfully;

            while (currentPosition < maxPosistion)
            {
                isSuccessfully = true;

                for (int positionInSearchString = maxSearchPosition; positionInSearchString > -1; positionInSearchString--, currentPosition--)
                {
                    if (currentString[currentPosition] != searchString[positionInSearchString])
                    {
                        isSuccessfully = false;
                        currentPosition = offsetTable.Any(x => x.Key == currentString[currentPosition])
                            ? currentPosition + offsetTable.Single(x => x.Key == currentString[currentPosition]).Value : currentPosition + offsetTable['#'];

                        break;
                    }
                }

                if (isSuccessfully)
                {
                    return new HorspoolModel
                    {
                        InputString = currentString,
                        SearchString = searchString,
                        NumberOfLine = currentPosition + 1,
                        IsFound = true
                    };
                }
            }

            return new HorspoolModel
            {
                InputString = currentString,
                SearchString = searchString,
                NumberOfLine = 0,
                IsFound = false
            };
        }

        private Dictionary<char, int> GetOffsetTable(string searchString)
        {
            Dictionary<char, int> offsetTable = new Dictionary<char, int>();
            int lengthString = searchString.Length - 2;

            for (int positionInSearchString = lengthString; positionInSearchString > -1; positionInSearchString--)
            {
                if (offsetTable.Any(x => x.Key == searchString[positionInSearchString]))
                {
                    continue;
                }

                offsetTable.Add(searchString[positionInSearchString], lengthString - positionInSearchString + 1);
            }

            offsetTable.Add('#', lengthString + 2);
            return offsetTable;
        }
    }
}
