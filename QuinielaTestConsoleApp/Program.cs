using QuinielaLibrary.Pools;
using System;
using System.IO;
using UtilsLibrary.Serialization;

namespace QuinielaTestConsoleApp
{
    class Program
    {
        static Writter wr = new Writter();
        static Readder rd = new Readder();
        static Test test = new Test();
        static void Main(string[] args)
        {
            test.crearLiga();
            writeToFile("Liga", serialize(test.ligaMX));
            test.CrearTemporada();
            writeToFile("Temporada", serialize(test.temporada));
            test.CrearEquipos();
            test.CrearJornada();
            writeToFile("Jornada 1", serialize(test.semana1));
            test.CrearQuiniela();
            writeToFile("Quiniela J1", serialize(test.Quiniela1));
            test.CrearGrupo();
            for (int i = 1; i < 5; i++)
            {
                test.CrearUsuario();
                test.CrearPrediccion();
                writeToFile(string.Format("{0}{1}", "Pred",i.ToString()), serialize(test.Prediccion1));
            }
            
            test.SetResultsOfWeek();
            writeToFile("Resultados Jornada 1", serialize(test.semana1));

            for (int i = 1; i < 5; i++)
            {
                string file = string.Format(@"{0}\{1}.{2}", System.Configuration.ConfigurationManager.AppSettings["Path"], string.Format("{0}{1}","Pred",i.ToString()), "json");
                test.Prediccion1 = rd.DeserializarJSON<Prediction>(rd.GetJsonFromFile<Prediction>(file));
                test.VerifyResults();
                test.AddPredictionToList();
                writeToFile(string.Format("{0}{1}", "Pred", i.ToString()), serialize(test.Prediccion1));
                Console.WriteLine(test.aciertos.ToString() + System.Environment.NewLine);
            }
            writeToFile("Lista de predicciones", serialize(test.PredictionsOfGroup));
            test.GetWeekClassification();
            writeToFile("Clasificatoria J1", serialize(test.WeekClassif));
            Console.ReadLine();
            
        }
        static string serialize(object data)
        {
            return wr.SerializarAJson(data);
        }
        static void writeToFile(string fileName, string data)
        {
            string path =string.Format(@"{0}\{1}.{2}", System.Configuration.ConfigurationManager.AppSettings["Path"], fileName, "json");
            File.WriteAllText(path, data);
        }
    }
}
