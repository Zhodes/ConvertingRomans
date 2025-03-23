namespace ConvertingRomans
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Läser ett konsol input och översätter det till en int
            static int NumberOfRomans()
            {

                int input = Int32.Parse(Console.ReadLine());
                return input;
            }

            //tar emot ett värde i form av en int, denna siffra avgör hur många nummer som ska översättas.
            //Sedan ber den om input från användaren like många gånger som som inputet. 
            //varje gång användaren ger ett input översätts det av funktionen RomanNumberToArabic och det arabiska numret sparas i arabicValues.
            // Efter det skriver funktionen ut det arabiska värdena till konsollen.
            static void ReadingRomans(int numberOfLines)
            {

                int[] arabicValues = new int[numberOfLines];
                for (int i = 0; i < numberOfLines; i++)
                {
                    arabicValues[i] = RomanNumberToArabic(Console.ReadLine());

                }

                for (int i = 0;i < arabicValues.Length; i++)
                {
                    Console.WriteLine(arabicValues[i]);
                }
            }

            //Tar emot ett invärde i form av en sträng som ska motvara ett romersk nummer. 
            //Returnerar en int som är den Arabiska motsvarigheten till det Romerska nummret.
            static int RomanNumberToArabic(string romanNumber)
            {
                //Ett dictionary som används för att översätta romerska siffror till arabiska.
                Dictionary<char, int> RomanArabicDict = new Dictionary<char, int>();
                RomanArabicDict.Add('I', 1);
                RomanArabicDict.Add('V', 5);
                RomanArabicDict.Add('X', 10);
                RomanArabicDict.Add('L', 50);
                RomanArabicDict.Add('C', 100);
                RomanArabicDict.Add('D', 500);
                RomanArabicDict.Add('M', 1000);
                int[] romanNumberArray = new int[romanNumber.Length];

                //ett array med de enskilda siffrorna i det romerska nummret översatta till arabiska. 
                for (int i = 0; i < romanNumber.Length; i++)
                {
                    romanNumberArray[i] = RomanArabicDict[romanNumber[i]];
                }

                //detta nummer är det som kommer bli vårt slutgiltiga arabiska nummer
                int arabicNumber = 0;
                //den största romerska siffran i nummret. 
                int largestRomanNumber = 0;

                //en for loop som går igenom det romerska nummret i omvänd ordning och börjar med den sista siffran.
                //Om siffran i är större än largestRomanNumber sätts largestRomanNumber = i och i adderas till arabicNumber.
                //Om i är mindre än largestRomanNumber subtraheras den från arabicNumber.
                //Annars adderas den till arabicNumber, vilket bara inträffar när i är lika med largestRomanNumber. 
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



            //anroppar ReadingRomans med funktionen NumberOfRomans som invärde
            static void ConvertingRomans()
            {
                ReadingRomans(NumberOfRomans());
            }

            ConvertingRomans();
        }
    }
}
