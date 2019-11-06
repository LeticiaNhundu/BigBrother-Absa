using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BigBrotherAPI.Services;
using RabbitMQ.Client;
using System.Collections.Generic;
using BigBrotherAPI.Models;
using System.IO;
using System.Threading.Tasks;

namespace BigBrotherApi.Services
{
    public class VideoService : IVideoService
    {

        public Task<IActionResult> PostRecognition(IFormFile files)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())


            using (var channel = connection.CreateModel())
            {//declaration of queue to publish data on
                channel.QueueDeclare(queue: "Recognition",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

                // data to be passed. this is where the video data will be used instead
                var body = files;

                //  byte[] body1 = Encoding.UTF8.GetBytes(files);
                var ms = new MemoryStream();
                files.CopyTo(ms);
                byte[] filebytes = ms.ToArray();
                var fileB = new BinaryReader(ms);
                //   var s = Convert.ToBase64String(filebytes);


               // int FileID = 91;
                IBasicProperties prop = channel.CreateBasicProperties();
                prop.Headers = new Dictionary<string, object>();
               // prop.Headers.Add("ID", FileID);

                // the actual publishing of the data
                channel.BasicPublish(exchange: "",
                                     routingKey: "Recognition",
                                     basicProperties: prop,
                                     body: filebytes);

                return null;

            }
        }


        public Task<IActionResult> PostTraining(IFormFile file, string abNumber)
        {
            string filePath = "C:/Users/leticia.nhundu/Desktop/BigBrother/BigBrotherPython/names.txt";
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())


            using (var channel = connection.CreateModel())
            {//declaration of queue to publish data on
                channel.QueueDeclare(queue: "Training",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

                // data to be passed. this is where the video data will be used instead
                var body = file;

                //  byte[] body1 = Encoding.UTF8.GetBytes(files);
                var ms = new MemoryStream();
                file.CopyTo(ms);
                byte[] filebytes = ms.ToArray();
                var fileB = new BinaryReader(ms);
                //   var s = Convert.ToBase64String(filebytes);

          
                    IBasicProperties prop = channel.CreateBasicProperties();
                prop.Headers = new Dictionary<string, object>();
                prop.Headers.Add("ID", abNumber);

                // the actual publishing of the data
                channel.BasicPublish(exchange: "",
                                     routingKey: "Training",
                                     basicProperties: prop,
                                     body: filebytes);

                return null;

            }

        }
    }
}
