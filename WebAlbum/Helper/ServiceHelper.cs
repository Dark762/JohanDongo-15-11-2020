using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using WebAlbum.Models;

namespace WebAlbum.Helper
{
    public class ServiceHelper
    {


        public List<ALbumModel> getListaAlbum()
        {


                List<ALbumModel> AlbumInfo = new List<ALbumModel>();

                using (var client = new HttpClient())
                {

                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    var Res = client.GetAsync("https://jsonplaceholder.typicode.com/albums").Result;

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var Response = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        AlbumInfo = JsonConvert.DeserializeObject<List<ALbumModel>>(Response);

                    }
                    //returning the employee list to view  
                    return AlbumInfo;
                }


        }

        public List<PhotoModel> getListaPhotos(ALbumModel request)
        {



            List<PhotoModel> PhotoInfo = new List<PhotoModel>();

            using (var client = new HttpClient())
            {



                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                var Res =  client.GetAsync("https://jsonplaceholder.typicode.com/photos").Result;

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var Response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    PhotoInfo = JsonConvert.DeserializeObject<List<PhotoModel>>(Response);

                }
                //returning the employee list to view  
                return PhotoInfo.Where(x => x.albumId == request.id).ToList();
            }

        }


        public List<Comentarios> getComentarioPhoto(PhotoModel request)
        {



            List<Comentarios> ComentarioInfo = new List<Comentarios>();

            using (var client = new HttpClient())
            {



                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                var Res = client.GetAsync("https://jsonplaceholder.typicode.com/comments").Result;

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var Response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    ComentarioInfo = JsonConvert.DeserializeObject<List<Comentarios>>(Response);

                }
                //returning the employee list to view  
                return ComentarioInfo.Where(x => x.id == request.id).ToList();
            }

        }

    }
}