using DentElora.Entities;
using System.Drawing.Drawing2D;

namespace DentElora.Models
{
    public class HomePageViewModel
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<Treatment> Treatments { get; set; }
        public IEnumerable<HomeInfo> HomeInfos { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public HomePageViewModel()
        {
            Sliders = new List<Slider>();
            Doctors = new List<Doctor>();
            Treatments = new List<Treatment>();
            HomeInfos= new List<HomeInfo>();
            Services = new List<Service>();
        }
    }
}
