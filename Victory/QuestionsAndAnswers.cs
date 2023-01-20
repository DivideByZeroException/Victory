using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victory
{
    internal class QuestionsAndAnswers
    {
        public QuestionsAndAnswers(string vopr, string otvet)
        {
            Vopr = vopr;
            Otvet = otvet;
        }
        [BsonId]
        public ObjectId Id { get; set; }

        public string Vopr { get; set; }

        public string Otvet { get; set; }
    }
}
