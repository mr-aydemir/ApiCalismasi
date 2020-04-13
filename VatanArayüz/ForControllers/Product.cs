using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForControllers.VatanArayüz
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EMarka Marka { get; set; }
        public double Cost { get; set; }
        public string Url { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public IList<ImageModel> Images { get; set; } = new List<ImageModel>();
        public string ImageUrl;

    }
}

public enum EMarka : byte
{
    [Description("LENOVO")]
    LENOVO = 1,

    [Description("ASUS")]
    ASUS = 2,

    [Description("SAMSUNG")]
    SAMSUNG = 3,

    [Description("ACER")]
    ACER = 4,

    [Description("APPLE")]
    APPLE = 5,

    [Description("DELL")]
    DELL = 5,

    [Description("HUAWEI")]
    HUAWEİ = 5,

    [Description("HP")]
    HP = 5,

    [Description("HOMETECH")]
    HOMETECH = 5
}