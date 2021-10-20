using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADC
{
    class ADConverter
    {
        public double[] analog;
        public double[] kvantalt;
        public Random r;
        public int min; //min érték
        public int max; //max érték
        public int db; //sorozat hosssza

        public double resolution;

        //public int kvantkar;
        public int binarycode;

        public ADConverter()
        {
            getMin();
            getMax();
            getDb();

            r = new Random();

            analog = new double[db];
            kvantalt = new double[db];

            setAnalog();
            //kiir();
            getBinaryCode();
            
            getResolution();
            getQuanted();
            getDigitatized();

        }

        public int getMin()  //ide még kéne ellenőrzött bekérés + double
        {
            Console.WriteLine("Kérem adja meg a minimum értéket!");
            min = int.Parse(Console.ReadLine());
            return min;
        }

        public int getMax() //ide még kéne ellenőrzött bekérés
        {
            Console.WriteLine("Kérem adja meg a maximum értéket!");
            max= int.Parse(Console.ReadLine());
            return max;
        }

        public int getDb() //a tömb elemszámának bekérése
        {
            Console.WriteLine("Kérem adja meg a tömb elemszámát!");
            db = int.Parse(Console.ReadLine());
            return db;
        }

        public void setAnalog() //az analog[] tömb feltöltése véletlen számokkal
        {

            for (int i = 0; i < db; i++)
            {
                analog[i] = Convert.ToDouble(r.Next(min, max + 1));

            }
 

        }

      /*  
        public void kiir()
        {

            Console.Write("A generált számsorozat: ");
            foreach (double elem in analog)
            {
                Console.Write(elem+" ");
            }
        }
      */

        public int getBinaryCode() //bekérem, a 2 kitevőjét
        {

            Console.WriteLine();
            Console.WriteLine("Kitevő (M): ");
            binarycode = int.Parse(Console.ReadLine());

            return binarycode;
        }

        public double getResolution() //a mintavételezés felbontása: (maxérték-minérték)/a 2"kitevőedik" hatványával
        {
            double resolution = Convert.ToDouble((analog.Max() - analog.Min()) / Math.Pow(2, binarycode));

            Console.WriteLine("Felbontás (d): "+resolution);

            return resolution;
        }

        public void getQuanted() //az előzőleg megkapott d paraméterrel (resolution) elosztom a mért adatot és feltöltöm, a kvantált tömbbe
        {
            double sgd;
            resolution = getResolution();

            for (int i = 0; i < db; i++)
            {
                sgd = analog[i];
                kvantalt[i] = sgd/resolution;
                // Console.WriteLine(kvantalt[i]);
              /*  if (kvantalt[i]<0)
                {
                    kvantalt[i] *=-1;
                }
              */
            }


        }

        public void getDigitatized() 
        {
            string[] binArray = new string[db];
            int hatvany = Convert.ToInt32(Math.Pow(2, binarycode));

            for (int i = 0; i < db; i++)
            {

                string seged = Convert.ToString(Convert.ToInt32(kvantalt[i]), 2);


                binArray[i] = seged;

                Console.Write("<Bemeneti duplapontos érték: "+analog[i]+ ">\t"+"<A kvantált érték: " + Math.Round(kvantalt[i]) + ">\t" + "<Bináris kódszó: ");

               

                if (binArray[i].Length<=hatvany)
                {
                    Console.Write(binArray[i]+">");
                    Console.WriteLine();
                }

               
                else
                {
                    Console.Write(binArray[i].Substring(0, hatvany)+">");
                    Console.WriteLine();
                    
                }
            }
        }


    }
}
