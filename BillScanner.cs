using System;
using System.Drawing;
using System.Drawing.Imaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tesseract;

namespace BillScanner
{
    class BillScanner
    {
        static void Main(string[] args)
        {
            // Örnek JSON yanıtı
            string jsonResponse = @"{
                ""description"": ""FIRMA ADI: Örnek Market\nTARİH: 2023-07-15\nTOPLAM TUTAR: 150.00 TL"",
                ""coordinates"": {
                    ""x"": 100,
                    ""y"": 50,
                    ""width"": 300,
                    ""height"": 100
                }
            }";

           
            JObject parsedResponse = JObject.Parse(jsonResponse);

            // Reading Text and Coordinates
            string description = parsedResponse["description"].ToString();
            JObject coordinates = parsedResponse["coordinates"] as JObject;

            int x = (int)coordinates["x"];
            int y = (int)coordinates["y"];
            int width = (int)coordinates["width"];
            int height = (int)coordinates["height"];

            string imagePath = "path_to_your_image.jpg";

            //  OCR Engine
            using (var engine = new TesseractEngine("./tessdata", "eng", EngineMode.Default))
            {
                // Taking Image
                using (var img = Pix.LoadFromFile(imagePath))
                {
                    // Scanning Coordinate
                    using (var page = engine.Process(img, Rect.FromCoords(x, y, x + width, y + height)))
                    {
                        string text = page.GetText();

                        
                        Console.WriteLine("Scanned Bill Context : ");
                        Console.WriteLine(text);
                    }
                }
            }
        }
    }
}
