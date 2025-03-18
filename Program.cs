namespace ConvertingRomans
{
    internal class Program
    {
        static void Main(string[] args)
        {


            static int NumberOfRomans()
            {

                int input = Int32.Parse(Console.ReadLine());
                return input;
            }

            static void ReadingRomans(int numberOfLines)
            {

                int[] arabicValues = new int[numberOfLines];
                for (int i = 0; i < numberOfLines; i++)
                {
                    arabicValues[i] = RomanNumberToArabic2(Console.ReadLine());

                }

                for (int i = 0;i < arabicValues.Length; i++)
                {
                    Console.WriteLine(arabicValues[i]);
                }
            }

            /*static string[] RomanNumbersToArabic(string[] romanNumbers)
            {
                string[] arabicNumbers = new string[romanNumbers.Length];
                for (int i = 0;i < romanNumbers.Length;i++)
                {
                    arabicNumbers[i] = RomanNumberToArabic(romanNumbers[i]);
                }
                return arabicNumbers;

            }*/

            //static void ConvertingRomans(string[] romanValues) { }

            static int RomanNumberToArabic(string romanNumber)
            {
                Dictionary<char, int> RomanArabicDict = new Dictionary<char, int>();
                RomanArabicDict.Add('I', 1);
                RomanArabicDict.Add('V', 5);
                RomanArabicDict.Add('X', 10);
                RomanArabicDict.Add('L', 50);
                RomanArabicDict.Add('C', 100);
                RomanArabicDict.Add('D', 500);
                RomanArabicDict.Add('M', 1000);
                int[] romanNumberArray = new int[romanNumber.Length];

                for (int i = 0; i < romanNumber.Length; i++)
                {
                    romanNumberArray[i] = RomanArabicDict[romanNumber[i]];
                }


                
                int arabicNumber = 0;

                for (int i = 0; i < romanNumber.Length; i++)
                {
                    /*if ((i == romanNumber.Length - 1) || (RomanArabicDict[romanNumber[i].ToString()] >= RomanArabicDict[romanNumber[i + 1].ToString()]))
                    {
                        arabicNumber += RomanArabicDict[romanNumber[i].ToString()];
                    }
                    else
                    {
                        arabicNumber -= RomanArabicDict[romanNumber[i].ToString()];
                    }*/


                    int valueToSubtract = romanNumberArray[i];
                    int valueToAdd = romanNumberArray[i];
                    int moveiTo = i;
                    if (i != romanNumber.Length - 1)
                    {
                        bool repeatingNumber = true;
                        bool arabicNumberUpdated = false;
                        for (int j = i + 1; j < romanNumber.Length; j++)
                        {

                            if (romanNumberArray[i] != romanNumberArray[j]) repeatingNumber = false;
                            if (repeatingNumber)
                            {
                                valueToAdd += romanNumberArray[j]; 
                                moveiTo = j;
                            }
                            
                            if (romanNumberArray[i] < RomanArabicDict[romanNumber[j]])
                            {

                                arabicNumber -= valueToSubtract;
                                arabicNumberUpdated = true;
                                moveiTo = j-1;
                                break;
                            }

                            valueToSubtract += romanNumberArray[j];



                        }
                        if (arabicNumberUpdated) {
                            i = moveiTo;
                            continue; }
                        else {
                            arabicNumber += valueToAdd;
                            i = moveiTo;
                            continue;
                        }
                            

                    }
                    arabicNumber += valueToAdd;


                }
                return arabicNumber;
            }

            static int RomanNumberToArabic2(string romanNumber)
            {
                Dictionary<char, int> RomanArabicDict = new Dictionary<char, int>();
                RomanArabicDict.Add('I', 1);
                RomanArabicDict.Add('V', 5);
                RomanArabicDict.Add('X', 10);
                RomanArabicDict.Add('L', 50);
                RomanArabicDict.Add('C', 100);
                RomanArabicDict.Add('D', 500);
                RomanArabicDict.Add('M', 1000);
                int[] romanNumberArray = new int[romanNumber.Length];

                for (int i = 0; i < romanNumber.Length; i++)
                {
                    romanNumberArray[i] = RomanArabicDict[romanNumber[i]];
                }

                int arabicNumber = 0;
                int largestRomanNumber = 0;
                for (int i = romanNumberArray.Length-1; i >=0 ; i--)
                {
                    if (romanNumberArray[i] > largestRomanNumber)
                    {
                        arabicNumber += romanNumberArray [i];
                        largestRomanNumber = romanNumberArray[i];
                    }
                    else if (romanNumberArray[i] < largestRomanNumber)
                    {
                        arabicNumber -= romanNumberArray[i];
                    }
                    else
                    {
                        arabicNumber += romanNumberArray[i];
                    }

                } 

                return arabicNumber;
            }

            /*static void WritingArabic(string[] arabicNumbers)
            {
                foreach (string arabicNumber in arabicNumbers)
                {
                    Console.WriteLine(arabicNumber);
                }
            }*/

            static void ConvertingRomans()
            {
                ReadingRomans(NumberOfRomans());
            }

            ConvertingRomans();
        }


        //Console.WriteLine(ReadingRomans(NumberOfRomans()));

    }
}
