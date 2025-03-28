namespace sample1;
using System;
using System.Diagnostics;
using Newtonsoft.Json;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;



class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");
        Person person = new Person("Donald Trump", 75);
        //person.name = "Donald Trump";
        //person.age = 75;
        //Console.WriteLine(person.Hello(false));

        string personObjectSerialized = JsonConvert.SerializeObject(person, Formatting.Indented);
        Console.WriteLine(personObjectSerialized);

        List<string> images = new List<string>{"img_base.png", "img2.png", "img3.png"};
        Stopwatch stopwatchSerial = new Stopwatch();

        stopwatchSerial.Start();
        imgModificationClassicalForEach(images);
        stopwatchSerial.Stop();
        Console.WriteLine(" Classical for loop time :" + stopwatchSerial.Elapsed);

        Stopwatch stopwatchParallel = new Stopwatch();
        stopwatchParallel.Start();
        imgModificationParallelForEach(images);
        stopwatchParallel.Stop();
        Console.WriteLine(" Parallel for loop time :" + stopwatchParallel.Elapsed);



        
        

         
        
    }
    static void imgModificationClassicalForEach(List<string> images){
        foreach (string imagePath in images){
            string path = @$".\img\{imagePath}";
            using (Image image = Image.Load(path)) 
            {
            Console.WriteLine(" -------------------------------------- ");
            Console.WriteLine($" Information about the first Image {imagePath}: ");
            Console.WriteLine($"Width: {image.Width}");
            Console.WriteLine($"Height: {image.Height}");
            // Resize the image in place and return it for chaining.
            // 'x' signifies the current image processing context.
            image.Mutate(x => x.Resize(image.Width / 5, image.Height / 5)); 

            // The library automatically picks an encoder based on the file extension then
            // encodes and write the data to disk.
            // You can optionally set the encoder to choose.
            image.Save(@$".\img\{imagePath}-tansformed.png"); 
            Console.WriteLine(" -------------------------------------- ");
            Console.WriteLine(" Information about the second Image : ");
            Console.WriteLine($"Width: {image.Width}");
            Console.WriteLine($"Height: {image.Height}");
            }
        }
    }
    static void imgModificationParallelForEach(List<string> images){
        Parallel.ForEach(images, imagePath =>
        {
        string path = @$".\img\{imagePath}";
            using (Image image = Image.Load(path)) 
            {
            Console.WriteLine(" -------------------------------------- ");
            Console.WriteLine($" Information about the first Image {imagePath}: ");
            Console.WriteLine($"Width: {image.Width}");
            Console.WriteLine($"Height: {image.Height}");
            // Resize the image in place and return it for chaining.
            // 'x' signifies the current image processing context.
            image.Mutate(x => x.Resize(image.Width / 5, image.Height / 5)); 

            // The library automatically picks an encoder based on the file extension then
            // encodes and write the data to disk.
            // You can optionally set the encoder to choose.
            image.Save(@$".\img\{imagePath}-tansformed.png"); 
            Console.WriteLine(" -------------------------------------- ");
            Console.WriteLine(" Information about the second Image : ");
            Console.WriteLine($"Width: {image.Width}");
            Console.WriteLine($"Height: {image.Height}");
            }
        } );
               
    }
}

