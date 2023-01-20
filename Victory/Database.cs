using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victory
{
    internal class Database
    {
        public static List<QuestionsAndAnswers> GetAll()
        {
            var client = new MongoClient();        
            var database = client.GetDatabase("Victorina");                       
            var collection = database.GetCollection<QuestionsAndAnswers>("QuestionsAndAnswers");          
            return collection.Find(x => true).ToList();


        }
        public static string AddToDB(QuestionsAndAnswers data)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("Victorina"); 
            var collection = database.GetCollection<QuestionsAndAnswers>("QuestionsAndAnswers");  
          

           
            collection.InsertOne(data);
               
            
            return "";
        }


    }
}
