

using DocumentFormat.OpenXml.EMMA;
using OpenXmlPowerTools;
using System.Collections.Generic;

namespace apiProject.Entities
{
    public class Court
    {
        public int Id { get; set; }
    
       public string Name { get; set; }
        public string City { get; set; }
 public DateTime operatingH  { get; set; }
      //  public int Size(List<Court> t )
      // {
          
       //     int len = 0;
        //    List<Court> f = t.First();
         //   while( f != null)
         //   {
          //      len++;

          //      f = f.Next();
         //   }

       //    return 45;

      // }
        //operatingH = DateTime.Now;
    }
}